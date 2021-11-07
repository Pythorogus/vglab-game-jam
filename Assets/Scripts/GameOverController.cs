using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    string gameName = "";
    void Start()
    {
        string lastWord = "";
        int totalVersus = 0;
        int totalPlatform = 0;
        int totalRacing = 0;
        StateController.selectedWords.ForEach(delegate(Word word){
            gameName += word.label + " ";
            totalVersus += word.versusValue;
            totalPlatform += word.platformValue;
            totalRacing += word.racingValue;
        });

        if (totalVersus > totalPlatform && totalVersus > totalRacing) {
            lastWord = "Fighting";
        }

        if (totalPlatform > totalVersus && totalPlatform > totalRacing) {
            lastWord = "Adventure";
        }    

        if (totalRacing > totalPlatform && totalRacing > totalVersus) {
            lastWord = "Racing";
        }

        gameName += lastWord;
        
        GameObject.Find("GameName").GetComponent<TMPro.TextMeshProUGUI>().text = gameName;

        StateController.selectedWords.Clear();

        StartCoroutine(FadeAudioSource.StartFade(SoundController.instance.music2, 1f, 0));
    }

    public void Retry()
    {
        SceneManager.LoadScene("Play");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Start");
    }
}
