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

        if(StateController.selectedWords.Count == 0){
            lastWord = "";
        }

        gameName += lastWord;
        
        GameObject.Find("GameName").GetComponent<TMPro.TextMeshProUGUI>().text = gameName;
        GameObject.Find("WordsNumber").GetComponent<TMPro.TextMeshProUGUI>().text = "Longueur : " + StateController.selectedWords.Count.ToString() + " mots !";

        float i = 1;
        StateController.selectedWords.ForEach(word => {
            AudioClip sound = (AudioClip) Resources.Load("Sounds/Voices/" + word.label.ToLower().Replace(" ", "").Replace("-", ""));
            StartCoroutine(DelayedClip(sound,i));
            i += 0.7f;
        });

        AudioClip sound = (AudioClip) Resources.Load("Sounds/Voices/" + lastWord.ToLower().Replace(" ", "").Replace("-", ""));
        StartCoroutine(DelayedClip(sound,i));

        StateController.selectedWords.Clear();

        StartCoroutine(FadeAudioSource.StartFade(SoundController.instance.music2, 1f, 0));
    }

    public void Retry()
    {
        AudioClip sound = (AudioClip) Resources.Load("Sounds/select");
        SoundController.instance.sound.PlayOneShot(sound);
        SceneManager.LoadScene("Play");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Start");
    }

    IEnumerator DelayedClip(AudioClip clip, float delay) {
        yield return new WaitForSeconds(delay);
        SoundController.instance.voice.PlayOneShot(clip);
    }
}
