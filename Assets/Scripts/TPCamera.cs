using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCamera : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;
    public float min, max, SmoothingRotation;

    bool playerIsMoving;
       
    private void LateUpdate()
    {
        playerIsMoving = GetComponentInParent<CharacterControllerV1>().isMoving;
        CamControl();

        //Debug.Log(playerIsMoving);
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, min, max);
        //Quaternion currentRot = Target.rotation;

        if (playerIsMoving) 
        { 
            Player.rotation = Quaternion.Slerp(Player.rotation,Quaternion.Euler(0, mouseX, 0),SmoothingRotation * Time.deltaTime);
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
    }
}
