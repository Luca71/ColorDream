using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaloonBehaviours : MonoBehaviour
{
    public Image Baloon1, Baloon2, Baloon4;

    float timer = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        Baloon2.gameObject.SetActive(false);
        Baloon4.gameObject.SetActive(false);
        if (Staticone.instance.Baloon1On)
        {
            Staticone.instance.Baloon1On = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Staticone.instance.Baloon1On)
        {
            timer-= Time.deltaTime;
            if (timer <= 0)
            {
                Baloon1.enabled = false;

                if(!Staticone.instance.Baloon2On)
                    Staticone.instance.Baloon2On = true;
                Staticone.instance.Baloon1On = false;
            }
        }

        if (Staticone.instance.Baloon2On)
        {
            Baloon2.gameObject.SetActive(true);
        }
        else
        {
            Baloon2.gameObject.SetActive(false);
        }

        if (Staticone.instance.Baloon4On)
        {
            Baloon4.gameObject.SetActive(true);
        }
    }
}
