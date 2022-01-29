using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubCheck : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Staticone.instance.WhiteHair)
        {
            GetComponent<PortalTrigger>().enabled = true;
        }
        else
        {
            GetComponent<PortalTrigger>().enabled = false;
        }
    }
}
