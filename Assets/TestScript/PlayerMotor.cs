using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    float moveSpeed = 4;
    float gravity = 6;

    Vector3 moveDirection;
    CharacterController controller;

    void start()
    {
        controller = GetComponent<CharacterController>();
    }

    void update()
    {
        move();


    }

    void move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection *= moveSpeed;

        }
        moveDirection.y -= gravity;
        controller.Move(moveDirection * Time.deltaTime);
        
    }
}
