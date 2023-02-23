using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : PlayerBaseController
{
   

    // Update is called once pe
    void Update()
    {
      
        ControlPlayerByButtons();
    }

    void LateUpdate()
    {
        RotatePlayer();
        MovePlayer();
    }

    private void ControlPlayerByButtons()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveFast();
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveSlow();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            MoveForward();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            MoveForward();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            MoveNormal();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            MoveNormal();
        }
    }

    private void RotatePlayer()
    {
        if (speed.x > 0)
        {
            transform.rotation =
                Quaternion
                    .Slerp(transform.rotation,
                    Quaternion.Euler(0f, maxAngle, 0f),
                    Time.deltaTime * rotationSpeed);
        }
        else if (speed.x < 0)
        {
            transform.rotation =
                Quaternion
                    .Slerp(transform.rotation,
                    Quaternion.Euler(0f, -maxAngle, 0f),
                    Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation =
                Quaternion
                    .Slerp(transform.rotation,
                    Quaternion.Euler(0f, 0f, 0f),
                    Time.deltaTime * rotationSpeed);
        }
    }
}
