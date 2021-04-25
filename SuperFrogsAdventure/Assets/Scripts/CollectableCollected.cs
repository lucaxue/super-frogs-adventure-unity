using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollected : MonoBehaviour
{

    [SerializeField] private Collider2D collider;
    [SerializeField] private int Score;
    private Collider2D collectable;

    // Update is called once per frame
      void Start()
    {
        collectable = GetComponent<Collider2D>(); // selecting collider 2d from unity 
    }

    void Update()
    {
        // CollectedOnTrigger(); // calling function on frame render
    }

    void OnTriggerEnter2D(Collider2D colliderTriggered){

        if(colliderTriggered.tag == "SuperFrog")
        {
            Destroy(collectable); // destroys collectable when collected
            //Add Score to Total score 
        }
    }
}
