using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad instance;

    public bool GreenGemPicked, RedGemPicked, BlueGemPicked;

    void Awake()
    {
        MakeInstance();
        DontDestroyOnLoad(this.gameObject);
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
}
