using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReelingState : PlayerBaseState
{
    private GameObject bobber;
    private GameObject reelArrow;

    //1 = left, 2 = right, 3 = down
    private int arrowDirection;

    private bool changing;

    private float chanceToChange = 25.0f; //From 0 (rare) to 100 (frequent)

    public float playerStrength = 60.0f;
    private float fishStrength; //From 0 (weak) to 1 (strong)

    private float landRadius = 1.0f;

    private FishInfo fishInfo;

    public override void EnterState(PlayerStateManager player)
    {
        //Get the bobber in this script
        bobber = player.GetComponent<PlayerStateManager>().currentBobber;
        reelArrow = player.GetComponent<PlayerStateManager>().reelArrow;

        //Generate initial arrow position as left or right
        float randomNumber = Random.Range(0.0f, 2.0f);

        //If less than 1, initialize as left
        if (randomNumber <= 1.0f)
        {
            arrowDirection = 1;
        }
        //If greater, initialize as right
        else
        {
            arrowDirection = 2;
        }

        reelArrow.GetComponent<ReelArrow>().StartDisplay(arrowDirection);

        //Initialize changing to false
        changing = false;

        //Set fish data so we know how strong fish is
        fishInfo = bobber.GetComponent<Bobber>().hookedFish;
        fishInfo.Reset();
        Debug.Log("Player fish info = " + fishInfo);
        fishStrength = fishInfo.fishStrength;
        Debug.Log(fishStrength);
        chanceToChange = fishInfo.chanceToChange;
        Debug.Log(chanceToChange);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        changing = reelArrow.GetComponent<ReelArrow>().changing;

        //Press the space bar while the bobber is close (The player catches the fish)
        if (Vector3.Distance(player.transform.position, bobber.transform.position) < landRadius)
        {
            //Update the field journal / wherever the data will be stored
            

            Debug.Log(fishInfo);

            //Destroy Fish and Bobber
            UnityEngine.Object.Destroy(bobber);

            reelArrow.GetComponent<ReelArrow>().Victory();

            //Return to movement state
            player.SwitchState(player.MovingState);
        }

        //Press the correct button
        else if ( ((arrowDirection == 1 && Input.GetKey(KeyCode.LeftArrow)) || (arrowDirection == 2 && Input.GetKey(KeyCode.RightArrow))) && Input.GetKeyDown(KeyCode.Space) && changing == false )
        {
            //Make the bobber take one step towards player
            float step = playerStrength * fishStrength * Time.deltaTime;
            bobber.transform.position = Vector3.MoveTowards(bobber.transform.position, player.transform.position, step);

            //Generate new random number
            float randomNumber = Random.Range(0.0f, 100.0f);
            //If it is less than or equal to chanceToChange, flip arrow
            if (randomNumber <= chanceToChange)
            {
                if (arrowDirection == 1)
                {
                    arrowDirection = 2;
                }
                else if (arrowDirection == 2)
                {
                    arrowDirection = 1;
                }

                reelArrow.GetComponent<ReelArrow>().WaitAndChangeArrow(arrowDirection, 6.0f);
            }
        }

        //Press the wrong button
        else if ( ((arrowDirection == 1 && Input.GetKey(KeyCode.RightArrow)) || (arrowDirection == 2 && Input.GetKey(KeyCode.LeftArrow))) && Input.GetKeyDown(KeyCode.Space) && changing == false)
        {
            Debug.Log("Reel Failure!");

            //Despawns bobbers (Signals fish to flee)
            UnityEngine.Object.Destroy(bobber);

            //Stop displaying the reel arrow
            reelArrow.GetComponent<ReelArrow>().StopDisplay();

            //Return to movement state
            player.SwitchState(player.MovingState);
        }

        else if (changing == true && Input.GetKeyDown(KeyCode.Space))
        {
            //Make the bobber take one step towards player
            float step = playerStrength * fishStrength * Time.deltaTime;
            bobber.transform.position = Vector3.MoveTowards(bobber.transform.position, player.transform.position, step);
        }
    }
}