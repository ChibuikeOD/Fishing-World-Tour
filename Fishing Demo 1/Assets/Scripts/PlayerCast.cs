using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCast : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public GameObject reticlePrefab;
    public GameObject bobberPrefab;

    public float reticleSpeed;

    private GameObject reticle;
    private GameObject bobber;

    private bool reticleCreated;
    private bool goingBack;
    private bool casting;

    public PlayerMovement moveScript;

    void Awake()
    {
        reticleCreated = false;
        casting = false;
        goingBack = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If not started casting, start casting
        if (reticleCreated == false && Input.GetKeyDown(KeyCode.Space))
        {
            moveScript.setCanMoveFalse();
            CreateReticle();
        }

        //If the Space key is held down, move the reticle out towards the endPoint
        else if (Input.GetKey(KeyCode.Space) && goingBack == false)
        {
            //Move the reticle towards the endpoint
            if ((reticle.transform.position - endPoint.position).sqrMagnitude > .001f * .001f)
            {
                float step = reticleSpeed * Time.deltaTime;
                reticle.transform.position = Vector3.MoveTowards(reticle.transform.position, endPoint.position, step);
            }
            //If the end point is reached, move the reticle back to the start
            else
            {
                goingBack = true;
            }
        }

        else if (Input.GetKey(KeyCode.Space) && goingBack == true)
        {
            //Move the reticle towards the endpoint
            if ((reticle.transform.position - startPoint.position).sqrMagnitude > .001f * .001f)
            {
                float step = reticleSpeed * Time.deltaTime;
                reticle.transform.position = Vector3.MoveTowards(reticle.transform.position, startPoint.position, step);
            }
            //If the end point is reached, move the reticle back to the start
            else
            {
                goingBack = false;
            }
        }

        //If it is released, spawn the bobber and move the reticle back to the start position.
        else if (casting == true)
        {
            bobber = Instantiate(bobberPrefab, reticle.transform.position, Quaternion.identity);

            //Spawn bobber
            Debug.Log("Bobber spawned");

            //Destroy Reticle and set reticleCreated to false
            Destroy(reticle);
            reticleCreated = false;

            //Set casting to false to exit the loop
            casting = false;

            //Let the player move again
            moveScript.setCanMoveTrue();
        }
    }

    private void CreateReticle()
    {
        //Instantiate the reticle at the start point
        reticle = Instantiate(reticlePrefab, startPoint.position, Quaternion.identity);

        //Player has started casting
        casting = true;

        //Player has created reticle
        reticleCreated = true;

        goingBack = false;
    }
}
