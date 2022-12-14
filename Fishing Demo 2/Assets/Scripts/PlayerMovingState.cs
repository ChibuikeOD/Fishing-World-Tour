using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerBaseState
{

    public float movementSpeed = 5f;

    public float xMin = -10f;
    public float xMax = 10f;
    public float yMin = -6f;
    public float yMax = -2f;

    public override void EnterState(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SwitchState(player.CastingState);
        }

        else
        {
            //Actual movement (Clamp may be unneccessary once we implement tilemaps, but we'll keep it for now
            float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;
            float horizontalPosition = Mathf.Clamp(player.transform.position.x + horizontalInput, xMin, xMax);

            float verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed;
            float verticalPosition = Mathf.Clamp(player.transform.position.y + verticalInput, yMin, yMax);

            Vector2 newPos = new Vector2(horizontalPosition, verticalPosition);
            player.transform.position = newPos;

            //Elementary rotation for now
            var rotationVector = player.transform.rotation.eulerAngles;

            if (Input.GetKeyDown(KeyCode.A))
            {
                rotationVector.z = 90;
                player.transform.rotation = Quaternion.Euler(rotationVector);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                rotationVector.z = 0;
                player.transform.rotation = Quaternion.Euler(rotationVector);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                rotationVector.z = 180;
                player.transform.rotation = Quaternion.Euler(rotationVector);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                rotationVector.z = -90;
                player.transform.rotation = Quaternion.Euler(rotationVector);
            }
        }
    }
}
