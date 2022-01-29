using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorMgr : MonoBehaviour
{
    public bool BW;
    public bool Colored;

    ICanChangeColor[] IcanChangeGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        IcanChangeGroup = Object.FindObjectsOfType<ICanChangeColor>();
        if (SceneManager.GetActiveScene().name == "REDROOM" )
        {
            if (Staticone.instance.RedGemPicked)
                Colored = true;
            else
                BW = true;
        }

        if (SceneManager.GetActiveScene().name == "GREENROOM")
        {
            if (Staticone.instance.GreenGemPicked)
                Colored = true;
            else
                BW = true;
        }

        if (SceneManager.GetActiveScene().name == "BLUEROOM")
        {
            if (Staticone.instance.BlueGemPicked)
                Colored = true;
            else
                BW = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BW)
        {
            BW = false;
            for (int i = 0; i < IcanChangeGroup.Length; i++)
            {
                if(IcanChangeGroup[i].textures.Length == 2)
                {
                    IcanChangeGroup[i].ChangeTextureInBW();
                }
                else
                {
                    Debug.Log(IcanChangeGroup[i].name);
                }
            }
        }

        if (Colored)
        {
            Colored = false;
            for (int i = 0; i < IcanChangeGroup.Length; i++)
            {
                IcanChangeGroup[i].ChangeTextureInColor();
            }
        }
    }
}
