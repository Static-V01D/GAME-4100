using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Target
    public Transform TargetObject;

    //Default distance between target and player
    public Vector3 cameraOffset;

    //Smoothness for camera roation
    public float smoothFactor = .5f;

    //Check that the camera looked at the target
    public bool LookAtTarget = false;
    
    void Start()
    {
        cameraOffset = transform.position - TargetObject.transform.position;
    }

    
    void LateUpdate()
    {
        Vector3 newPostion = TargetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position,newPostion, smoothFactor);


        //camera rotation change
        if(LookAtTarget)
        {
            transform.LookAt(TargetObject);
        }
    }
}
