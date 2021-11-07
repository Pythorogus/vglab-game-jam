using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    public AudioSource music1;
    public AudioSource music2;

    void Awake()
    {
        if(SoundController.instance == null) {
            DontDestroyOnLoad(this);
            SoundController.instance = this;
        } else {
            Destroy(gameObject);
        }

        SoundController.instance.music2.volume = 0;
    }

    void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        if(!SoundController.instance.music1.isPlaying){music1.Play();}
        if(!SoundController.instance.music2.isPlaying){music2.Play();}
    }
}
