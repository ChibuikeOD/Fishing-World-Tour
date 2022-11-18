using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    public enum State
    {
        Searching,
        Facing,
        Moving,
        Nibbling,
        Biting,
        PullingAway,
        Fleeing
    }

    public State state;

    public float searchRadius = 10f;
    public float searchAngle = 50f;
    
    public float rotationStrength = 5f;
    public float swimSpeed = 5f;

    public float biteLikeliness = 25f;
    public bool waiting;

    public GameObject bobber;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Searching;
        waiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Searching:
                SearchForBobber();
                break;
            case State.Facing:
                FaceBobber();
                break;
            case State.Moving:
                MoveToBobber();
                break;
            case State.Nibbling:
                Nibble();
                break;
            case State.Biting:
                Bite();
                break;
            case State.PullingAway:
                PullAway();
                break;
            case State.Fleeing:
                Flee();
                break;
        }
    }

    //Search for if there is a bobber in the fish's vicinity. If so, set it to 
    void SearchForBobber()
    {
        bobber = GameObject.Find("Bobber(Clone)");

        //Detect if the bobber has been created
        if (!(bobber == null))
        {
            //Detect if the bobber is close enough to the fish
            if(Vector3.Distance(transform.position, bobber.transform.position) < searchRadius)
            {
                Vector3 dirTowardsBobber = (bobber.transform.position - transform.position).normalized;
                float dotProduct = Vector3.Dot(dirTowardsBobber, transform.up);

                if (dotProduct > 0.1f)
                {
                    state = State.Facing;
                }
            }
        }
    }

    void FaceBobber()
    {
        if (bobber != null)
        {
            //Look towards the bobber
            float angle = Mathf.Atan2(bobber.transform.position.y - transform.position.y, bobber.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion bobberRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, bobberRotation, rotationStrength * Time.deltaTime);

            //Check if we are facing the bobber
            if (Vector3.Dot((bobber.transform.position - transform.position).normalized, transform.up) > 0.99999f)
            {
                state = State.Moving;
            }
        }
        else
        {
            state = State.Fleeing;
        }
    }

    void MoveToBobber()
    {
        if (bobber != null)
        {
            if ((transform.position - bobber.transform.position).sqrMagnitude > 1.25f)
            {
                float step = swimSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, bobber.transform.position, step);
            }
            else
            {
                state = State.Nibbling;
            }
        }
        else
        {
            state = State.Fleeing;
        }
    }

    void Nibble()
    {
        if (bobber != null)
        {
            if (waiting == false)
            {
                StartCoroutine(NibbleWait());
            }
        }
        else
        {
            state = State.Fleeing;
        }
    }

    void Bite()
    {
        //Wait for seconds. If the player hasn't hooked the fish, run
        if (waiting == false)
        {
            StartCoroutine(BiteWait());
        }

        //If the bobber is hooking, run away
        if (bobber.GetComponent<Bobber>().hooking == true)
        {
            //Joint fish to bobber
            gameObject.AddComponent<SpringJoint2D>();
            gameObject.GetComponent<SpringJoint2D>().autoConfigureDistance = false;
            gameObject.GetComponent<SpringJoint2D>().distance = 0.5f;
            gameObject.GetComponent<SpringJoint2D>().connectedBody = bobber.GetComponent<Rigidbody2D>();
            //gameObject.GetComponent<SpringJoint2D>().connectedAnchor = bobber.GetComponent<Rigidbody2D>();

            //Start pulling away
            state = State.PullingAway;
        }
    }

    void PullAway()
    {
        if (bobber != null)
        {
            
        }
        else
        {
            state = State.Fleeing;
        }
    }

    void Flee()
    {
        Destroy(gameObject);
    }

    IEnumerator NibbleWait()
    {
        waiting = true;

        yield return new WaitForSeconds(3);

        float randomNumber = Random.Range(0.0f, 100.0f);

        //Fish bit down on the bobber
        if (randomNumber <= biteLikeliness)
        {
            bobber.GetComponent<Bobber>().sunk = true;
            bobber.GetComponent<Bobber>().BiteAnimate();
            state = State.Biting;
        }
        //Merely nibbled
        else
        {
            bobber.GetComponent<Bobber>().NibbleAnimate();
        }
        waiting = false;
    }

    IEnumerator BiteWait()
    {
        waiting = true;

        yield return new WaitForSeconds(5);

        if (bobber.GetComponent<Bobber>().hooking == false)
        {
            state = State.Fleeing;
        }

        waiting = false;
    }
}

//Maybe have flee as result of being hooked and rename Flee to Fail