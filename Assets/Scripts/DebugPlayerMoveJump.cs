using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayerMoveJump : MonoBehaviour
{
    float speed = 200;
    float jumpPower = 60;
    bool canWalk = true;
    Rigidbody myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        PlayerJump();
        if (myBody.velocity.y > 0)
        {
            myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y -20, myBody.velocity.z);
        }
    }

    private void FixedUpdate()
    {
        PlayerWalk();
    }

    private void PlayerJump()
    {
        if (Input.GetButton("Jump"))
        {
            myBody.velocity = new Vector3(myBody.velocity.x, jumpPower, myBody.velocity.z);
        }
    }

    private void PlayerWalk()
    {
        if (canWalk)
        {
            float h = Input.GetAxisRaw("Vertical");
            if (h > 0)
            {
                myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y, speed * Time.deltaTime);
            }
            else if (h < 0)
            {
                myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y, -speed * Time.deltaTime);
            }
            else
            {
                myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y, 0);
            }

            //if (!jumped)
            //{
            //    anim.SetInteger("Speed", Mathf.Abs((int)myBody.velocity.x));
            //}
        }
    }
}
