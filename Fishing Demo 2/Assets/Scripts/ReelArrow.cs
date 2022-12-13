using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReelArrow : MonoBehaviour
{
    public Image image;

    public Sprite leftArrow;
    public Sprite rightArrow;
    public Sprite neutral;

    public Sprite blank;
    public Sprite victory;

    public bool changing;
    public bool victorybool;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the sprite as blank
        image.sprite = blank;
        changing = false;
    }

    public void StartDisplay(int arrowPosition)
    {
        victorybool = false;
        //Set Sprite to value arrow is initialized as by player
        if (arrowPosition == 1)
        {
            image.sprite = leftArrow;
        }

        else
        {
            image.sprite = rightArrow;
        }
    }

    public void StopDisplay()
    {
        //Set Sprite to blank, only called when reeling has ended
        image.sprite = blank;
        changing = false;
    }

    public void Victory()
    {
        victorybool = true;
        StartCoroutine(VictoryWait());
        changing = false;
    }

    public void WaitAndChangeArrow(int arrowPosition, float seconds)
    {
        //Wait seconds
        StartCoroutine(NeutralWait(arrowPosition, seconds));
    }

    IEnumerator VictoryWait()
    {
        image.sprite = victory;

        yield return new WaitForSeconds(2);

        image.sprite = blank;
    }

    IEnumerator NeutralWait(int arrowPosition, float seconds)
    {
        changing = true;

        //Set Sprite to neutral position
        image.sprite = neutral;

        //Wait seconds
        yield return new WaitForSeconds(1);

        //Change the arrow to passed in direction
        if (victorybool == false)
        {
            if (arrowPosition == 1)
            {
                image.sprite = leftArrow;
            }

            else
            {
                image.sprite = rightArrow;
            }
        }

        changing = false;

        //Add check here to make sure we don't change the arrow if the player has caught the fish during neutral time.000000000..................
    }
}

//Set the variable for changing in here, since this has the IEnumerator
