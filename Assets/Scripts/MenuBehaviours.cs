using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuBehaviours : MonoBehaviour
{
    public float OnMouseScale;
    public AudioMixer BGMixer;
    public Slider slider;

    Vector3 initSize;
    Vector3 newScale;

    private void Start()
    {
        initSize = transform.localScale;
        newScale = new Vector3(OnMouseScale, OnMouseScale, OnMouseScale);
    }

    public void OnValueChange()
    {
        Slider slider = GetComponent<Slider>();
        BGMixer.SetFloat("master", slider.value);
    }
   
    public void PlayOnClick()
    {
        AudioMgr.instance.PlayButtonSound();
        SceneManager.LoadScene("NEXUS");
    }

    public void QuitOnClick()
    {
        AudioMgr.instance.PlayButtonSound();
        Application.Quit();
    }

    public void PointerEnter()
    {
        transform.localScale = newScale;
    }
    public void PointerExit()
    {
        transform.localScale = initSize;
    }
}
