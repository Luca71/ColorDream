using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerV1 : MonoBehaviour
{
    public float Speed;
    public float GravityForce;
    public bool isFalling = false;
    public KeyCode JumpButton;
    public float FirstJumpSpeed, SecondJumpSpeed;

    [Space(20)]
    [Header("Toccare con cautela, per dubbi chiedete <3")]
    public float maxDistance;
    public float sphereRadius;
    public LayerMask layerMask;
    public bool CanJump,canDoubleJump, isMoving;
    float HVal, VVal;
    bool FirstJumpingCall, SecondJumpingCall;
    Ray myRay;
    RaycastHit HitInfo;
    Rigidbody rb;
    Animator anim;

    bool canWalk;
    Ray myFixingRay;
    RaycastHit HitInfoFixing;
    public float maxFixingDistance;
    public float sphereRadiusFixing;
    public LayerMask fixingLm;
    public float offsetY;
    public ParticleSystem flyPS;
    
    public Vector3 PosOnPlat;
    bool onPlat;
    GameObject plat;

    int jumpCount = 0;
    PlayerColorChange PCC;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        PCC = GetComponentInChildren<PlayerColorChange>();

        /* commented only for Luca Debug
        if (!Staticone.instance.RedHair || !Staticone.instance.BlueHair || !Staticone.instance.GreenHair)
        {
            PCC.ChangeFateColor(FateColor.white);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        VVal = Input.GetAxis("Vertical");
        HVal = Input.GetAxis("Horizontal");
        if (anim != null)
        {
            anim.SetFloat("Speed", VVal);
        }

        
        PlayerMovement(); //NO FIXED, DOESN?T JUMP RIGHT

        /* commented only for Luca Debug
        if (Staticone.instance.RedHair)
        {
            PCC.ChangeFateColor(FateColor.red);
            
        }
        if (Staticone.instance.GreenHair)
        {
            PCC.ChangeFateColor(FateColor.green);
            
        }
        if (Staticone.instance.BlueHair)
        {
            PCC.ChangeFateColor(FateColor.blue);
            
        }
        */
        
    }
    private void FixedUpdate()
    {
        MovementFixingForward();
        FlyPosition();
        Jump();
        Fall();
    }



    private void FlyPosition()
    {
        myRay.origin = transform.position;
        myRay.direction = Vector3.down;
        Debug.DrawRay(myRay.origin, myRay.direction * maxDistance, Color.cyan);

        //If raycast hits the floor my pos.y is infopoint + offset, else i'm falling
        if (!Physics.SphereCast(myRay, sphereRadius, out HitInfo, maxDistance))
        {
            isFalling = true;
        }

      
    }
    private void Fall()
    {
        if (rb.velocity.y > 0 || isFalling)
        {
            rb.velocity = new Vector3(0, rb.velocity.y - GravityForce, 0);
        }
    }
    private void Jump()
    {
        if (FirstJumpingCall)
        {
            jumpCount++;
            rb.AddForce(new Vector3(0, FirstJumpSpeed, 0), ForceMode.Impulse);
            
            FirstJumpingCall = false;
        }
        if (SecondJumpingCall)
        {
            rb.velocity = new Vector3(0, 0, 0);
            jumpCount++;
            SecondJumpingCall = false;
            rb.AddForce(new Vector3(0, SecondJumpSpeed, 0), ForceMode.Impulse);
            
        }
    }
    
    private void PlayerMovement()
    {
        if (canWalk)
        {
            Vector3 playerMovement = new Vector3(0f, 0f, VVal) * Speed * Time.deltaTime; //Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
        }

        if(jumpCount <= 2)
        {
            
            if (Input.GetKeyDown(JumpButton) && CanJump)
            {
                FirstJumpingCall = true;
                anim.SetTrigger("Jump");
                flyPS.Play();
               

                CanJump = false;
                canDoubleJump = true;
            }

            if (Input.GetKeyDown(JumpButton) && canDoubleJump)
            {
                SecondJumpingCall = true;
                anim.SetTrigger("Jump");
                flyPS.Play();
                
               

                canDoubleJump = false;
                CanJump = false;
            }
        }
        
        
            isMoving = (HVal != 0 || VVal !=0) ? true : false; //FIGO <3
    }



    // Fix mancato trasporto su piattaforma se entri senza saltare
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.SetParent(collision.gameObject.transform);
        }
        isFalling = false;
        CanJump = true;
        canDoubleJump = false;
        jumpCount = 0;

        if (collision.gameObject.tag == "Walls")
        {
            CanJump = false;
        }
    }
    //

    private void OnCollisionExit(Collision collision)
    {
        transform.parent = null;
    }

    void MovementFixingForward()
    {
        myFixingRay.origin = transform.position + new Vector3(0,offsetY,0);
        myFixingRay.direction = transform.forward;
        Debug.DrawRay(myFixingRay.origin, myFixingRay.direction * maxFixingDistance, Color.red);


        if (Physics.SphereCast(myFixingRay, sphereRadiusFixing, out HitInfoFixing, maxFixingDistance,fixingLm))
        {
            CanJump = false;
            canWalk = false;
            

        }
        else
        {
            canWalk = true;
        }
    }

    
}
