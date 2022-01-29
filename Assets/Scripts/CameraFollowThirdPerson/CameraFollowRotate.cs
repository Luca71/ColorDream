using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRotate : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    [SerializeField]
    private float cameraFollowSmoothness;
    [SerializeField]
    private float smoothRotation;

    private void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);
            return;
        }

      
        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            
            transform.position = Vector3.Lerp(transform.position, target.TransformPoint(offsetPosition),
                                                cameraFollowSmoothness * Time.deltaTime);
            //transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position, target.position + offsetPosition,
                                                cameraFollowSmoothness * Time.deltaTime);
            //transform.position = target.position + offsetPosition;
        }
  

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, smoothRotation * Time.deltaTime);
            //transform.rotation = target.rotation;
        }
    }
}
