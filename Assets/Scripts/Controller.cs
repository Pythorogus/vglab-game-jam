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
    int maxLife = 6;
    float timer = 5;
    int wordIndex = 0;

    void Start()
    {
        Shuffle(GetWordList());
        PrintLife();
        InitRandomWords();
        button1.onClick.AddListener(() => OnWordClick());
        button2.onClick.AddListener(() => OnWordClick(1));
        button3.onClick.AddListener(() => OnWordClick(2));
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        } else {
            ResetRandomWords();
            ResetTimer();
            versusLife -= decrement;
            platformLife -= decrement;
            racingLife -= decrement;
            
            PrintLife();
        }
        
        PrintTimer();

        if(versusLife <= 0 || platformLife <= 0 || racingLife <= 0){
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

    void OnWordClick(int wordIndexIncrement = 0){
        Word word = GetWordList()[wordIndex + wordIndexIncrement];
        var versusLifeSum = versusLife + word.versusValue - decrement;
        versusLife = versusLifeSum <= maxLife ? versusLifeSum : maxLife;
        var platformLifeSum = platformLife + word.platformValue - decrement;
        platformLife = platformLifeSum <= maxLife ? platformLifeSum : maxLife;;
        var racingLifeSum = racingLife + word.racingValue - decrement;
        racingLife = racingLifeSum <= maxLife ? racingLifeSum : maxLife;

        StateController.selectedWords.Add(word);
        PrintLife();
        ResetRandomWords();
        ResetTimer();
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
        versusLifePrint.GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("{0:0.00}",versusLife);
        platformLifePrint.GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("{0:0.00}",platformLife);
        racingLifePrint.GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("{0:0.00}",racingLife);
    }

    void PrintTimer()
    {
        timerPrint.GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("{0:0.00}",timer);
    }

    List<Word> GetWordList()
    {
        return data.GetComponent<Data>().wordList;
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
