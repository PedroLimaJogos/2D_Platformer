using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    public Rigidbody2D myRigidBody;

    public UnityEngine.Vector2 friction = new UnityEngine.Vector2(.1f, 0);

    public float jumpForce = 2;

    public float speed;
    private void Update()
    {
        handleJump();
        handleMovement();
    }

    private void handleMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.velocity = new UnityEngine.Vector2(speed, myRigidBody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);
            myRigidBody.velocity = new UnityEngine.Vector2(-speed, myRigidBody.velocity.y);
        }

        if (myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity -= friction;
        }
        if (myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity += friction;
        }
    }

    private void handleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = UnityEngine.Vector2.up * jumpForce;
        }
    }
}
