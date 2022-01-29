using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubBehavior : MonoBehaviour
{
    public GameObject RedGem;
    public GameObject GreenGem;
    public GameObject BlueGem;

    public ParticleSystem RedPS;
    public ParticleSystem BluePS;
    public ParticleSystem GreenPS;

    float timer = 10f;
    public void SetGemActive(string color)
    {
        switch (color)
        {
            case "Green":
                GreenGem.GetComponent<MeshRenderer>().enabled = true;
                break;

            case "Blue":
                BlueGem.GetComponent<MeshRenderer>().enabled = true;
                break;

            case "Red":
                RedGem.GetComponent<MeshRenderer>().enabled = true;
                break;
        }

    }

    private void Start()
    {
        //GEM PICKED
        if (Staticone.instance.RedGemPicked)
        {
            SetPSActive("Red");
        }

        if (Staticone.instance.GreenGemPicked)
        {
            SetPSActive("Green");
        }

        if (Staticone.instance.BlueGemPicked)
        {
            SetPSActive("Blue");
        }

        //GEM POSED
        if (Staticone.instance.BlueGemPosed)
        {
            SetGemActive("Blue");
        }

        if (Staticone.instance.RedGemPosed)
        {
            SetGemActive("Red");
        }

        if (Staticone.instance.GreenGemPosed)
        {
            SetGemActive("Green");
        }
    }

    private void Update()
    {
        if (Staticone.instance.GreenGemPosed && Staticone.instance.BlueGemPosed && Staticone.instance.RedGemPosed)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void SetPSActive(string color)
    {
        switch (color)
        {
            case "Green":
                GreenPS.Play();
                break;

            case "Blue":
                BluePS.Play();
                break;

            case "Red":
                RedPS.Play();
                break;
        }

    }

    public void SetPSStop(string color)
    {
        switch (color)
        {
            case "Green":
                GreenPS.Stop();
                break;

            case "Blue":
                BluePS.Stop();
                break;

            case "Red":
                RedPS.Stop();
                break;
        }

    }
}
