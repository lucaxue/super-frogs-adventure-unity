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
        Movement();

    }

    IEnumerator Movement() 
    {
        rbStone.velocity = new Vector2(rbStone.velocity.x, -3);
        yield return new WaitForSeconds(2);
        rbStone.velocity = new Vector2(rbStone.velocity.x, 3);
    }
}
