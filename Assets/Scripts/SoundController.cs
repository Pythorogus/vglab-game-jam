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
        Debug.Log("AWAKE SOUND CONTROLLER");
        if(SoundController.instance == null) {
            DontDestroyOnLoad(this);
            SoundController.instance = this;
        } else {
            Destroy(gameObject);
        }
        Debug.Log("AFTER DESTROY");

        SoundController.instance.music2.volume = 0;
    }

    void Start()
    {
        Debug.Log("START SOUND CONTROLLER");
        PlayMusic();
    }

    public void PlayMusic()
    {
        if(!SoundController.instance.music1.isPlaying){music1.Play();}
        if(!SoundController.instance.music2.isPlaying){music2.Play();}
    }
}
