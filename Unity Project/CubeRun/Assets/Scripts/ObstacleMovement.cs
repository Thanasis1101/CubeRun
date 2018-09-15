using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    public Rigidbody obstacle;
    public float speed = 20f;
    public float limit = 6f;
    private bool directionIsLeft = true;
    private bool hit = false;

	// Move the obstacle left and right

	void FixedUpdate () {

        if (!hit)
        {

            if (directionIsLeft)
            {
                if (transform.position.x > -limit)
                {
                    obstacle.AddForce(-speed, 0, 0);
                }
                else
                {
                    directionIsLeft = false;
                    // stop movement
                    obstacle.velocity = Vector3.zero;
                    obstacle.angularVelocity = Vector3.zero;
                }
            }
            else
            {
                if (transform.position.x < limit)
                {
                    obstacle.AddForce(speed, 0, 0);
                }
                else
                {
                    directionIsLeft = true;
                    // stop movement
                    obstacle.velocity = Vector3.zero;
                    obstacle.angularVelocity = Vector3.zero;
                }

            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        // the player hit the moving obstacle

        if (collision.collider.name == "Player")
        {
            Debug.Log("AAA");
            hit = true;
        }
    }

}
