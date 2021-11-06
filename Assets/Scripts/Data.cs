using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data : MonoBehaviour
{
    public List<Word> wordList = new List<Word>();

    void Start()
    {
        ReadCSVFile();
    }

    void ReadCSVFile()
    {
        StreamReader strReader = new StreamReader("Assets/data.csv");
        bool endOfFile = false;
        bool firstLoop = true;
        while(!endOfFile)
        {
            string dataString = strReader.ReadLine();
            if (dataString == null)
            {
                endOfFile = true;
                break;
            }
            string[] dataValues = dataString.Split(';');
            if(!firstLoop){
                Word word = new Word(dataValues[0], int.Parse(dataValues[1]), int.Parse(dataValues[2]), int.Parse(dataValues[3]));
                Debug.Log(word.label);
                Debug.Log(word.versusValue);
                wordList.Add(word);
            }else{
                firstLoop = false;
            }
        }
        /*
        wordList.ForEach(word => {
            Debug.Log("Word : " + word.label + ", " + word.versusValue.ToString() + ", " + word.platformValue.ToString() + ", " + word.racingValue.ToString());
        });
        */
    }
}
