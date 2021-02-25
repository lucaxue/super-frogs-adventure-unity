using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //make rigidbody field
    private Rigidbody2D rb;
    private Animator animator;

    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
        Animation();
    }


    void OnTriggerEnter2D(Collider2D colliderTriggered)
    {
        if (colliderTriggered.tag == "DeathBox")
        {
            SceneManager.LoadScene("MainLevel");
        }
    }

    void Movement()
    {
        var xAxis = Input.GetAxis("Horizontal");
        var jumpAxis = Input.GetAxis("Jump");
        //right and left movement
        if (xAxis < 0)
        {
            //change rb's velocity to a new 2d vector
            //x: -5, y: same as it is
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        if (xAxis > 0)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }


        if (jumpAxis > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
        }
    }

    void Animation()
    {

        //idle
        if (rb.velocity == new Vector2(0, 0))
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        //if moving to the left or right
        if (rb.velocity.x > 0.5 || rb.velocity.x < -0.5)
        {
            animator.SetBool("isRunning", true);
        }


        //jumping
        if (rb.velocity.y > 0.5)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
        }
        //falling
        if (rb.velocity.y < -0.5)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);

        }
    }

}
