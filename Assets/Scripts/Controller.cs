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
    public GameObject racingHearts;
    public GameObject versusHearts;
    public GameObject platformHearts;
    public GameObject data;
    public GameObject timerPrint;
    public Button button1, button2, button3;
    int maxLife = 3;
    float timer = 5;
    int wordIndex = 0;
    public Man racing_man;
    public Man versus_man;
    public Man platform_man;
    public SalesMan sales_man;
    public Reaction racing_man_reaction;
    public Reaction versus_man_reaction;
    public Reaction platform_man_reaction;
    public GameObject wordButtons;
    public GameObject wordResult;
    public GameObject timerObject;

    void Start()
    {
        Shuffle(GetWordList());
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
            AdaptHearts(racingHearts,racingLife) ;
            AdaptHearts(versusHearts,versusLife) ;
            AdaptHearts(platformHearts,platformLife) ;
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
        StartCoroutine(WordSequence(wordIndexIncrement));
    }

    void DisableTimer()
    {
        timerObject.SetActive(false);
    }

    void EnableTimer()
    {
        ResetTimer();
        timerObject.SetActive(true);
    }

    void ResetTimer(){
        timer = 5;
    }

    void ResetWords(){
        wordIndex = 0;
        Shuffle(GetWordList());
    }

    void PrintTimer()
    {
        timerPrint.GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("{0:0.00}",timer);
    }

    List<Word> GetWordList()
    {
        return data.GetComponent<Data>().wordList;
    }

    void PlayManAnimation(Man man, Reaction reaction, int value, float delay)
    {
        switch(value){
            case 0 :
                man.PlayDislikeAnimation(delay);
                reaction.PlayDislikeAnimation(delay);
                break;
            case 1 :
                man.PlayOkAnimation(delay);
                reaction.PlayOkAnimation(delay);
                break;
            case 2 :
                man.PlayLikeAnimation(delay);
                reaction.PlayLikeAnimation(delay);
                break;
            case 3 :
                man.PlayLoveAnimation(delay);
                reaction.PlayLoveAnimation(delay);
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

    IEnumerator WordSequence(int wordIndexIncrement)
    {
        Word word = GetWordList()[wordIndex + wordIndexIncrement];

        wordButtons.SetActive(false);
        wordResult.GetComponent<TMPro.TextMeshProUGUI>().text = word.label;
        wordResult.SetActive(true);
        DisableTimer();

        sales_man.PlayShowAnimation(0);

        if(versusLife > 0 || platformLife > 0 || racingLife > 0){
            AudioClip sound = (AudioClip) Resources.Load("Sounds/Voices/" + word.label.ToLower().Replace(" ", "").Replace("-", ""));
            SoundController.instance.voice.PlayOneShot(sound);
        }

        yield return new WaitForSeconds(1f);
        
        var racingLifeSum = racingLife + word.racingValue - decrement;
        racingLife = racingLifeSum <= maxLife ? racingLifeSum : maxLife;
        AdaptHearts(racingHearts, racingLife);
        PlayManAnimation(racing_man, racing_man_reaction, word.racingValue, 0);
        
        var versusLifeSum = versusLife + word.versusValue - decrement;
        versusLife = versusLifeSum <= maxLife ? versusLifeSum : maxLife;
        AdaptHearts(versusHearts, versusLife);
        PlayManAnimation(versus_man, versus_man_reaction, word.versusValue, 0.25f);

        var platformLifeSum = platformLife + word.platformValue - decrement;
        platformLife = platformLifeSum <= maxLife ? platformLifeSum : maxLife;
        AdaptHearts(platformHearts, platformLife);
        PlayManAnimation(platform_man, platform_man_reaction, word.platformValue, 0.5f);

        StateController.selectedWords.Add(word);

        ResetRandomWords();
        
        yield return new WaitForSeconds(1.5f);

        wordButtons.SetActive(true);
        wordResult.SetActive(false);
        EnableTimer();
    }

    void AdaptHearts(GameObject hearts, float life)
    {
        switch (life) {
            case 0 :
                break;
            case 1 :
                hearts.transform.Find("heart2").transform.Find("heart_red").gameObject.SetActive(false);
                hearts.transform.Find("heart3").transform.Find("heart_red").gameObject.SetActive(false);
                break;
            case 2 :
                hearts.transform.Find("heart2").transform.Find("heart_red").gameObject.SetActive(true);
                hearts.transform.Find("heart3").transform.Find("heart_red").gameObject.SetActive(false);
                break;
            case 3 :
                hearts.transform.Find("heart2").transform.Find("heart_red").gameObject.SetActive(true);
                hearts.transform.Find("heart3").transform.Find("heart_red").gameObject.SetActive(true);
                break;
        }
    }
}
