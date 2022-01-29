using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDIsabled : MonoBehaviour
{
    public Camera Cam;
    public void DisableCam()
    {
        Cam.enabled = false;
    }

    public void EnableCam()
    {
        Cam.enabled = true;
        
    }
}
