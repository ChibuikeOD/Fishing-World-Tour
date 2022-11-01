using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public bool canMove;

    void Awake()
    {
        //Let the player move at the start
        canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            //Actual movement (Clamp may be unneccessary once we implement tilemaps, but we'll keep it for now
            float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;
            float horizontalPosition = Mathf.Clamp(transform.position.x + horizontalInput, xMin, xMax);

            float verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed;
            float verticalPosition = Mathf.Clamp(transform.position.y + verticalInput, yMin, yMax);

            Vector2 newPos = new Vector2(horizontalPosition, verticalPosition);
            transform.position = newPos;

            //Elementary rotation for now
            var rotationVector = transform.rotation.eulerAngles;

            if (Input.GetKeyDown(KeyCode.A))
            {
                rotationVector.z = 90;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                rotationVector.z = 0;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                rotationVector.z = 180;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                rotationVector.z = -90;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
        }
    }

    public void setCanMoveTrue()
    {
        canMove = true;
    }
    public void setCanMoveFalse()
    {
        canMove = false;
    }
}
