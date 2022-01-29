using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staticone : MonoBehaviour
{
    public static Staticone instance;

    public bool GreenGemPicked, RedGemPicked, BlueGemPicked;
    public bool GreenHair, RedHair, BlueHair, WhiteHair;
    public bool GreenGemPosed, RedGemPosed, BlueGemPosed;
    public bool Baloon2On, Baloon4On;
    public bool Baloon1On;

    void Awake()
    {
        MakeInstance();
        DontDestroyOnLoad(this.gameObject);
        Baloon1On = true;
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
