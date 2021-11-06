using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Data : MonoBehaviour
{
    public List<Word> wordList;

    void Awake()
    {
        //Debug.Log("DATA AWAKE");
        wordList = new List<Word>();
        ReadCSVFile();
    }

    void ReadCSVFile()
    {
        try
        {
            using(StreamReader strReader = new StreamReader("Assets/data.csv"))
            {
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
                    string[] dataValues = dataString.Split(',');
                    if(!firstLoop){
                        Word word = new Word(dataValues[0], int.Parse(dataValues[1]), int.Parse(dataValues[2]), int.Parse(dataValues[3]));
                        wordList.Add(word);
                    }else{
                        firstLoop = false;
                    }
                }
                //Debug.Log("READ CSV : " + wordList.Count.ToString() + " elements");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        /*
        wordList.ForEach(word => {
            Debug.Log("Word : " + word.label + ", " + word.versusValue.ToString() + ", " + word.platformValue.ToString() + ", " + word.racingValue.ToString());
        });
        */
    }
}
