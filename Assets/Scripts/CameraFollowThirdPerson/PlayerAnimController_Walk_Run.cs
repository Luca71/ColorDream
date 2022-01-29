using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController_Walk_Run : MonoBehaviour {

    public Transform myTransform;
    public bool sendTranslateParam, sendRotateParam;
    public bool translateRoot, rotateRoot;
	public float rotationBoost = 1;

    void FixedUpdate () {
		var x = Input.GetAxis("Horizontal");
		var z = Input.GetAxis("Vertical");

		if (translateRoot)
            myTransform.Translate(0, 0, z*0.1f);
		if(rotateRoot)
            myTransform.Rotate(0, x*rotationBoost, 0);
    }
}
