using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    Vector3 defaultPosition;

    public bool RightLeft, UpDown, ForwardBackward;
    public float speedX, speedY, speedZ, minX, maxX, minY, maxY, minZ, maxZ;

    public float defaulTimer;
    public float RespawnTimer;
    float timer;
    float resTimer;
    public bool isActive;
    MeshRenderer mr;
    BoxCollider bc;

    ICanChangeColor iCanChangeColor;

    // Start is called before the first frame update
    void OnEnable()
    {
        defaultPosition = transform.position;
        timer = defaulTimer;
        resTimer = RespawnTimer;
        mr = GetComponent<MeshRenderer>();
        bc = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        iCanChangeColor = GetComponent<ICanChangeColor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                mr.enabled = false;
                bc.enabled = false;
                transform.position = defaultPosition;

                resTimer -= Time.deltaTime;
            }

            if (resTimer <= 0)
            {
                mr.enabled = true;
                bc.enabled = true;
                timer = defaulTimer;
                resTimer = RespawnTimer;
                isActive = false;
            }

            if (UpDown)
            {
                Vector3 moveY = new Vector3(0, speedY * Time.deltaTime, 0);
                transform.position += moveY;
                if (transform.position.y >= defaultPosition.y + maxY)
                {
                    speedY = -speedY;
                }
                else if (transform.position.y <= defaultPosition.y - minY)
                {
                    speedY = speedY * -1;
                }
            }

            if (RightLeft)
            {
                Vector3 moveX = new Vector3(speedX * Time.deltaTime, 0, 0);
                transform.position += moveX;
                if (transform.position.x >= defaultPosition.x + maxX)
                {
                    speedX = -speedX;
                }
                else if (transform.position.x <= defaultPosition.x - minX)
                {
                    speedX = speedX * -1;
                }
            }

            if (ForwardBackward)
            {
                Vector3 moveZ = new Vector3(0, 0, speedZ * Time.deltaTime);
                transform.position += moveZ;
                if (transform.position.z >= defaultPosition.z + maxZ)
                {
                    speedZ = -speedZ;
                }
                else if (transform.position.z <= defaultPosition.z - minZ)
                {
                    speedZ = speedZ * -1;
                }
            }
        }

        if (!isActive)
        {
            // Change color from white
            iCanChangeColor.ChangeTextureInBW();
        }
        
    }

    public void ActivePlatform()
    {
        isActive = true;
    }

}
