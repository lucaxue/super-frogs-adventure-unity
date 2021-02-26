using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneFaceController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 2f;
    [SerializeField] private LayerMask ground;
    private Rigidbody2D rbStone;
    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 nextPos;
    void Start()
    {
        rbStone = GetComponent<Rigidbody2D>();
        startPos = rbStone.position;
        endPos = new Vector2(rbStone.position.x, rbStone.position.y - 2);
        nextPos = endPos;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //move towards
        rbStone.position = Vector2.MoveTowards(rbStone.position, nextPos, speed * Time.deltaTime);

        if (Vector2.Distance(rbStone.position, nextPos) <= 0.1 || rbStone.IsTouchingLayers(ground))
        {
            ChangeTargetPosition();
        }
    }

    void ChangeTargetPosition()
    {
        nextPos = nextPos != startPos ? startPos : endPos;
    }
}
