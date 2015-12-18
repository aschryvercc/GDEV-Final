using UnityEngine;
using System.Collections;
using System;

//[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

    float moveSpeed = 6;
    public Controller2D controller;
    float gravity = -20;
    Vector3 velocity;
    private bool faceRight = true;
    public Animator animator;

    void start()
    {
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity.x = input.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (velocity.x > 0 || velocity.x < 0)
        {
            animator.SetBool("playerMoving", true);
            animator.SetBool("playerStopRunning", false);
            animator.SetBool("playerStartRunning", true);
        }
        else if (velocity.x == 0)
        {
            if (input.x == 0)
            {
                animator.SetBool("playerMoving", false);
                animator.SetBool("playerStartRunning", false);
                animator.SetBool("playerStopRunning", true);
            }
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


 //   public float restartLevelDelay = 1f;
 //   public float speed;
 //   public float jump;
 //   private float moveVelocity;
 //   bool grounded = true;
 //   private Animator animator;

	//// Use this for initialization
	//protected override void Start ()
 //   {
 //       animator = GetComponent<Animator>();

 //       base.Start();    
	//}

 //   private void OnDisable()
 //   {

 //   }

 //   private void CheckIfGameOver()
 //   {

 //   }

 //   protected override void AttemptMove<T>(int xDir, int yDir)
 //   {
 //       base.AttemptMove<T>(xDir, yDir);
 //       RaycastHit2D hit;
 //       CheckIfGameOver();
 //   }

 //   protected override void OnCantMove<T>(T component)
 //   {

 //   }

 //   // Update is called once per frame
 //   void Update ()
 //   {
 //       int horizontal = 0;
 //       int vertical = 0;

 //       horizontal = (int)Input.GetAxisRaw("Horizontal");
 //       vertical = (int)Input.GetAxisRaw("Vertical");

 //       //if (horizontal != 0 || vertical != 0)
 //       //    AttemptMove<Wall>(horizontal, vertical);
	//}
}
