using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardSpeed = 3000f;
    public float sidewaySpeed = 40f;
    public float jumpSpeed = 8f;
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool jump = false;
    private bool canJump = false;
    public Collider playerCollider;
    public Collider groundCollider;

    // Update for physics

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardSpeed * Time.deltaTime);

        if (moveLeft)
        {
            rb.AddForce(-sidewaySpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (moveRight)
        {
            rb.AddForce(sidewaySpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (jump)
        {
            rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
            jump = false;
        }

    }

    void Update()
    {

        // check if player has fallen from ground

        if (rb.position.y < 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }


        // ----------- Computer Controls ----------- //

        if (!FindObjectOfType<GameManager>().paused)
        {

            // LEFT RIGHT

            if (Input.GetKeyDown("left"))
            {
                moveLeft = true;
            }

            if (Input.GetKeyUp("left"))
            {
                moveLeft = false;
            }

            if (Input.GetKeyDown("right"))
            {
                moveRight = true;
            }

            if (Input.GetKeyUp("right"))
            {
                moveRight = false;
            }


            // JUMP

            if (Input.GetKeyDown("up") || Input.GetKeyDown("space"))
            {
                jump = canJump; // jump only if can jump
            }


        }
        




        // ----------- Android Controls ----------- //

        if (Application.platform == RuntimePlatform.Android) {

            if (Input.touchCount > 0)
            {

                // LEFT RIGHT

                if (Input.GetTouch(0).phase == TouchPhase.Stationary)
                {
                    if (Input.GetTouch(0).position.x < Screen.width / 2)
                    {   // User touched left side of phone
                        moveLeft = true;
                    }
                    else
                    {   // User touched right side of phone
                        moveRight = true;
                    }
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    if (Input.GetTouch(0).position.x < Screen.width / 2)
                    {   // User released left side of phone
                        moveLeft = false;
                    }
                    else
                    {   // User released right side of phone
                        moveRight = false;
                    }
                }


                // JUMP

                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    if (Input.GetTouch(0).deltaPosition.y > 10)
                    {
                        jump = canJump;
                    }
                }
            }



            /* With phone acceleration
            if (Input.acceleration.x < 0)
            {   // Left
                moveLeft = true;
                moveRight = false;
            }
            else if (Input.acceleration.x == 0)
            {   // Center
                moveLeft = false;
                moveRight = false;
            }
            else
            {   // Right
                moveLeft = false;
                moveRight = true;
            }*/


        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true; // can jump because player is on ground
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false; // can't jump because player is not on ground
    }

}
