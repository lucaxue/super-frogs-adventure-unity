using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneFaceController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rbStone;
    void Start()
    {
        rbStone = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        //move with velocity
        //if position is 3 below
        //stop moving
        var originalY = rbStone.position.y;
        rbStone.velocity = new Vector2(rbStone.velocity.x, -3);
        if (rbStone.position == new Vector2(rbStone.position.x, originalY - 1))
        {
            rbStone.velocity = new Vector2(0, 0);
        }
        yield return new WaitForSeconds(2);
        rbStone.velocity = new Vector2(rbStone.velocity.x, 3);
        if (rbStone.position == new Vector2(rbStone.position.x, originalY + 1))
        {
            rbStone.velocity = new Vector2(0, 0);
        }
        yield return new WaitForSeconds(2);
    }
}
