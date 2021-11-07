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
        SceneManager.LoadScene("Play");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
