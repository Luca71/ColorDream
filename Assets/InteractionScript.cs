using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    BoxCollider myCollider;
    PlatformMovement temp;
    PlayerColorChange PCC;
    GameObject myOther;
    GameObject MySocket;

    ICanChangeColor iCanChangeColor;

    // Partycell
    public ParticleSystem Interacted;
    public ParticleSystem InteractableUI;

    public GameObject AnimatedCam;
    Animator animCAM;

    public bool onCrystal, onPlatform, onSocket;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        PCC = GameObject.FindGameObjectWithTag("ColorChanger").GetComponentInChildren<PlayerColorChange>();
        onCrystal = false;
        onPlatform = false;
        //AnimatedCam = GameObject.FindGameObjectWithTag("AnimatedCam");
        animCAM = AnimatedCam.GetComponent<Animator>();
    }

    private void Update()
    {
        if(onPlatform && Input.GetMouseButtonDown(0))
        {
            temp = myOther.GetComponent<PlatformMovement>();

            // Baloom
            Staticone.instance.Baloon2On = false;
            temp.ActivePlatform();
            Interacted.Play();
            onPlatform = false;
        }

        if(onCrystal && Input.GetMouseButtonDown(0))
        {
            if(myOther.name == "SM_CrystalGem_Red")
            {
                PCC.FateColor = FateColor.red;
                PCC.Change = true;
                Staticone.instance.RedHair = true;
                Staticone.instance.WhiteHair = false;
                
                myOther.GetComponent<Krist>().ColorAtivation();

                //ANIMATION CAMERA
                if (AnimatedCam != null)
                    AnimatedCam.SetActive(true);
                
            }
            else if(myOther.name == "SM_CrystalGem_Blue")
            {
                PCC.FateColor = FateColor.blue;
                PCC.Change = true;
                Staticone.instance.BlueHair = true;
                Staticone.instance.WhiteHair = false;
                
                myOther.GetComponent<Krist>().ColorAtivation();

                //ANIMATION CAMERA
                if(AnimatedCam != null)
                AnimatedCam.SetActive(true);

            }
            else if(myOther.name == "SM_CrystalGem_Green")
            {
                PCC.FateColor = FateColor.green;
                PCC.Change = true;
                Staticone.instance.GreenHair = true;
                Staticone.instance.WhiteHair = false;
                
                myOther.GetComponent<Krist>().ColorAtivation();

                //ANIMATION CAMERA
                if (AnimatedCam != null)
                    AnimatedCam.SetActive(true);
            }
            InteractableUI.Stop();
            myOther.gameObject.SetActive(false);
            onCrystal = false;
        }

        if (onSocket && Input.GetMouseButtonDown(0))
        {
            HubBehavior HubB = MySocket.GetComponent<HubBehavior>();
            if (Staticone.instance.RedGemPicked && !Staticone.instance.RedGemPosed)
            {
                HubB.SetGemActive("Red");
                HubB.SetPSStop("Red");
                Staticone.instance.RedHair = false;
                Staticone.instance.RedGemPosed = true;
            }
            if (Staticone.instance.BlueGemPicked && !Staticone.instance.BlueGemPosed)
            {
                HubB.SetGemActive("Blue");
                HubB.SetPSStop("Blue");
                Staticone.instance.BlueHair = false;
                Staticone.instance.BlueGemPosed = true;
            }
            if (Staticone.instance.GreenGemPicked && !Staticone.instance.GreenGemPosed)
            {
                HubB.SetGemActive("Green");
                HubB.SetPSStop("Green");
                Staticone.instance.GreenHair = false;
                Staticone.instance.GreenGemPosed = true;
            }

            if(Staticone.instance.GreenGemPosed && Staticone.instance.BlueGemPosed && Staticone.instance.RedGemPosed)
            {
                Staticone.instance.Baloon4On = true;
            }

            PCC.ChangeFateColor(FateColor.white);
            PCC.Change = true;
            Staticone.instance.WhiteHair = true;
            Interacted.Play();
            onSocket = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //INTERAZIONE PIATTAFORME
        if (other.tag == "Platform")
        {
            myOther = other.gameObject;
            onPlatform = true;
            InteractableUI.Play();
            Debug.Log("PLATFORM OnTriggerStay from Interaction");
            temp = myOther.GetComponent<PlatformMovement>();
            if (temp.isActive)
            {
                InteractableUI.Stop();
            }

            // Change color from white
            iCanChangeColor = other.GetComponent<ICanChangeColor>();
            iCanChangeColor.ChangeTextureInColor();

            
        }
        //INTERAZIONE CRISTALLI
        if(other.tag == "Crystal")
        {
            myOther = other.gameObject;
            onCrystal = true;
            Debug.Log("CRYSTAL");
            InteractableUI.Play();
        }

        //INTERAZIONE SOCKET
        if (other.tag == "Socket")
        {
            MySocket = other.gameObject;
            onSocket = true;
            Debug.Log("SOCKET");
            InteractableUI.Play();

        }

    }

    private void OnTriggerExit(Collider other)
    {
        onPlatform = false;
        onCrystal = false;
        InteractableUI.Stop();
    }

}
