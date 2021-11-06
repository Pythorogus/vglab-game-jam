using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    void Start()
    {

    }

    public void Retry()
    {
        SceneManager.LoadScene("Play");
    }
}
