using UnityEngine;
using System.Collections;
using System;

//[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {
    
    public Controller2D controller;
    public float jumpHeight = 0.5f;
    public float timeToJumpApex = 3f;
    float accelerationTimeAirborne = 0.2f;
    float accelerationTimeGrounded = 0.1f;
    float moveSpeed = 6;

    float gravity;
    float jumpVelocity;
    float velocityXSmoothing;
    Vector3 velocity;
    private bool faceRight = true;
    public Animator animator;

    void Awake()
    {
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        //print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }

    void Update()
    {
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
            animator.SetBool("playerIdleJump", false);
            animator.SetBool("playerFowardJump", false);
            animator.SetBool("playerMoving", false);
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }
        

        velocity.x = input.x * moveSpeed;
        //velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        print("X: " + velocity.x + "  Y: " + velocity.y + " Moving? " + animator.GetBool("playerMoving"));

        if (velocity.x > 0 || velocity.x < 0 &&
            controller.collisions.below)
        {
            animator.SetBool("playerMoving", true);
            animator.SetBool("playerStopRunning", false);
            animator.SetBool("playerStartRunning", true);
        }
        else if (velocity.x == 0 &&
            controller.collisions.below)
        {
            if (input.x == 0)
            {
                animator.SetBool("playerMoving", false);
                animator.SetBool("playerStartRunning", false);
                animator.SetBool("playerStopRunning", true);
            }
        }

        if (velocity.y > 0 &&
            !animator.GetBool("playerMoving") && 
            !controller.collisions.below)
        {
            animator.SetBool("playerIdleJump", true);
        }
        else if (velocity.y > 0 &&
            animator.GetBool("playerMoving") &&
            !controller.collisions.below)
        {
            animator.SetBool("playerFowardJump", true);
        }
        else
        {
            animator.SetBool("playerIdleJump", false);
            animator.SetBool("playerFowardJump", false);
        }
        
        if (velocity.x > 0 && !faceRight)
        {
            Flip();
        }
        if (velocity.x < 0 && faceRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
