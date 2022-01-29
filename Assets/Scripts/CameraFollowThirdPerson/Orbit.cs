using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    Transform player;

    //[SerializeField]
    private Vector3 offset;
    //[SerializeField]
    private float cameraFollowSmoothness;
    //[SerializeField]
    private float smoothRotation;
    [SerializeField]
    Vector2 YZPositionOffset;

    void Start()
    {
        //offset = new Vector3(player.position.x, player.position.y + 4.0f, player.position.z + 3.0f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = new Vector3(player.position.x, player.position.y +YZPositionOffset.x, player.position.z + YZPositionOffset.y);
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }

    void LateUpdate()
    {
        transform.position = player.position + offset;

        if (Input.GetMouseButton(0))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
            transform.LookAt(player.position);
        }
    }
}
