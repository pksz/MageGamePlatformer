using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothspeed;
    Vector3 velocity = Vector3.zero;
    public Vector3 offset;
   
    // Update is called once per frame
 
    void FixedUpdate()
    {
        if (characterController2D.isalive)
        {
            followPlayer();
        }
     
    }


    void followPlayer()
    {

        Vector3 desiredposition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredposition, ref velocity, smoothspeed);


        transform.position = smoothedPosition;


    }






}


