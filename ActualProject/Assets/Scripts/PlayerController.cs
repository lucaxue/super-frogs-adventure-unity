using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //make rigidbody field
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
}
