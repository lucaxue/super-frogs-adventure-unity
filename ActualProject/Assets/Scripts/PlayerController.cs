using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //make rigidbody field
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
    }   
       

    void Movement()
    {
 
        var xAxis = Input.GetAxis("Horizontal");
        var jumpAxis = Input.GetAxis("Jump");
        //right and left movement
        if (xAxis < 0)
        {
            animator.SetBool("isRunning", true);
            //change rb's velocity to a new 2d vector
            //x: -5, y: same as it is
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        } 

        if(rb.velocity == new Vector2(0, 0))
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }


        if (xAxis > 0)
        {
            animator.SetBool("isRunning", true);
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        } 


        if (jumpAxis > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
        }
        
        if(rb.velocity.y > 0.5)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
        }

         if(rb.velocity.y < -0.5)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);

        }
    }
 
}
