using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeAudioSource.StartFade(SoundController.instance.music2, 1f, 0));
    }

    public void Play()
    {
        AudioClip sound = (AudioClip) Resources.Load("Sounds/select");
        SoundController.instance.sound.PlayOneShot(sound);
        SceneManager.LoadScene("Play");
    }
}
