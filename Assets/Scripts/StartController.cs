using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play()
    {
        AudioClip sound = (AudioClip) Resources.Load("Sounds/select");
        SoundController.instance.sound.PlayOneShot(sound);

        SceneManager.LoadScene("Tuto");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
