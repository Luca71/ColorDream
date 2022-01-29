using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody Player;
    public float Speed,h,v;
    private Vector3 tempVect;

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
            
        tempVect = new Vector3(h, 0, v);
        tempVect = tempVect.normalized * Speed * Time.deltaTime;
        Player.MovePosition(Player.transform.position + tempVect);

        Quaternion rot = Quaternion.Euler(0, h, 0) * Quaternion.LookRotation(transform.forward, Vector3.up);
        Player.MoveRotation(rot);
    }
}
