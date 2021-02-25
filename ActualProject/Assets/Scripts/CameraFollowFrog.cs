using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFrog : MonoBehaviour
{
   public Transform SuperFrog;
   public float cameraDistance = 30.0f;

   void Awake()
   { 
       GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);

   }

   void FixedUpdate()
   {
     transform.position = new Vector3(SuperFrog.position.x, SuperFrog.position.y + 1, transform.position.z);
   }


}
