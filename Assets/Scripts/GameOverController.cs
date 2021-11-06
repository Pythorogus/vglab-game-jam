using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    string gameName = "";
    void Start()
    {
        string lastWord = "Simulator";
        int totalVersus = 0;
        int totalPlatform = 0;
        int totalRacing = 0;
        Debug.Log(StateController.selectedWords.Count);
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
    }

    public void Retry()
    {
        SceneManager.LoadScene("Play");
    }
}
