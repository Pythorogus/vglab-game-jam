using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public float versusLife;
    public float platformLife;
    public float racingLife;
    public float decrement;
    public GameObject data;
    public GameObject timerPrint;
    public GameObject versusLifePrint;
    public GameObject platformLifePrint;
    public GameObject racingLifePrint;
    public Button button1, button2, button3;
    int maxLife = 3;
    float timer = 5;
    int wordIndex = 0;

    public Man racing_man;
    public Man versus_man;
    public Man platform_man;

    void Start()
    {
        Shuffle(GetWordList());
        PrintLife();
        InitRandomWords();
        button1.onClick.AddListener(() => OnWordClick());
        button2.onClick.AddListener(() => OnWordClick(1));
        button3.onClick.AddListener(() => OnWordClick(2));
        StartCoroutine(FadeAudioSource.StartFade(SoundController.instance.music2, 1f, 0.4f));
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        } else {
            AudioClip sound = (AudioClip) Resources.Load("Sounds/losetime");
            SoundController.instance.sound.PlayOneShot(sound);
            ResetRandomWords();
            ResetTimer();
            versusLife -= decrement;
            platformLife -= decrement;
            racingLife -= decrement;
            
            PrintLife();
        }
        
        PrintTimer();

        if(versusLife <= 0 || platformLife <= 0 || racingLife <= 0){
            SoundController.instance.voice.Stop();
            AudioClip sound = (AudioClip) Resources.Load("Sounds/gameover");
            SoundController.instance.sound.PlayOneShot(sound);
            SceneManager.LoadScene("GameOver");
        }
    }

    void InitRandomWords(){
        if(wordIndex >= GetWordList().Count){ ResetWords(); }
        button1.gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GetWordList()[wordIndex].label;
        if(wordIndex+1 >= GetWordList().Count){ ResetWords(); }
        button2.gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GetWordList()[wordIndex+1].label;
        if(wordIndex+2 >= GetWordList().Count){ ResetWords(); }
        button3.gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GetWordList()[wordIndex+2].label;
    }

    void ResetRandomWords(){
        wordIndex += 3;
        InitRandomWords();
    }

    void OnWordClick(int wordIndexIncrement = 0)
    {
        Word word = GetWordList()[wordIndex + wordIndexIncrement];
        
        var racingLifeSum = racingLife + word.racingValue - decrement;
        racingLife = racingLifeSum <= maxLife ? racingLifeSum : maxLife;
        PlayManAnimation(racing_man, word.racingValue);
        
        var versusLifeSum = versusLife + word.versusValue - decrement;
        versusLife = versusLifeSum <= maxLife ? versusLifeSum : maxLife;
        PlayManAnimation(versus_man, word.versusValue);

        var platformLifeSum = platformLife + word.platformValue - decrement;
        platformLife = platformLifeSum <= maxLife ? platformLifeSum : maxLife;
        PlayManAnimation(platform_man, word.platformValue);

        StateController.selectedWords.Add(word);
        
        PrintLife();
        ResetRandomWords();
        ResetTimer();

        if(versusLife > 0 || platformLife > 0 || racingLife > 0){
            AudioClip sound = (AudioClip) Resources.Load("Sounds/Voices/" + word.label.ToLower().Replace(" ", "").Replace("-", ""));
            SoundController.instance.voice.PlayOneShot(sound);
        }
    }

    void ResetWords(){
        wordIndex = 0;
        Shuffle(GetWordList());
    }

    void ResetTimer(){
        timer = 5;
    }

    void PrintLife()
    {
        versusLifePrint.GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("{0}",versusLife);
        platformLifePrint.GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("{0}",platformLife);
        racingLifePrint.GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("{0}",racingLife);
    }

    void PrintTimer()
    {
        timerPrint.GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("{0:0.00}",timer);
    }

    List<Word> GetWordList()
    {
        return data.GetComponent<Data>().wordList;
    }

    void PlayManAnimation(Man man, int value)
    {
        Debug.Log("GO!");
        switch(value){
            case 0 :
                man.PlayDislikeAnimation();
                break;
            case 1 :
                man.PlayOkAnimation();
                break;
            case 2 :
                man.PlayLikeAnimation();
                break;
            case 3 :
                man.PlayLoveAnimation();
                break;
            default:
                break;
        }
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++) {
            var current = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = current;
        }
    }
}
