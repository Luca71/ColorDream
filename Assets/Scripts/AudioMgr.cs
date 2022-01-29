using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr instance;

    public AudioSource
        ButtonAudioSource,
        JumpAudioSource,
        BGAudioSource;

    public AudioClip[] AudioClips;


    private void Awake()
    {
        MakeInstance();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayBGSound(AudioClips[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayButtonSound()
    {
        ButtonAudioSource.Play();
    }

    public void PlayJumpSound()
    {
        JumpAudioSource.Play();
    }

    public void PlayBGSound(AudioClip audioClip)
    {
        BGAudioSource.clip = audioClip;
        BGAudioSource.loop = true;
        BGAudioSource.Play();
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
