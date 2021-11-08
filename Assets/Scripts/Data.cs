using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Data : MonoBehaviour
{
    public List<Word> wordList;

    private string csv = "Action,1,1,1;Armored,1,0,2;Astro,0,1,2;Attack,2,1,0;Bachelor,2,2,2;Basic,0,1,2;Battle,2,1,0;Beastmaster,2,1,0;Bionical,2,1,0;Bloody,3,0,0;Boost,0,0,3;Brawl,3,0,0;Bros,0,3,0;Budokai,3,0,0;Chrono,0,0,3;Coaster,0,3,0;Cobra,2,0,1;Combat,2,1,0;Commander,1,2,0;Commando,2,1,0;Condor,1,0,2;Control,0,0,3;CosmicForce,2,1,0;Crazy,2,1,3;Cryptical,0,3,0;Dark,1,2,0;Dash,0,0,3;Death,1,1,1;Defender,2,1,0;Deja Vu,0,0,3;Deluxe,0,1,2;Demon,2,1,0;Desert,0,1,2;Dodger,0,2,1;Doomed,2,1,0;Double,2,2,2;Dragon,1,2,0;Driver,0,0,3;Electric Boogaloo,2,2,2;Explosing,1,1,1;Extended,2,2,2;Extra,2,2,2;Falling,0,3,0;Final,2,2,2;Fire,1,1,1;Flash,0,0,3;Force,2,1,0;Freaking,1,1,1;Funky,0,2,1;Gaiden,2,1,0;Ghost,2,1,0;Gold,2,2,2;Grand,1,0,2;GT,0,0,3;Haunted,1,2,0;Hawk,2,2,2;Holy Knight,1,2,0;Hunter,2,1,0;Jungle,1,2,0;Karate,3,0,0;Knockout,3,0,0;Kung-Fu,2,1,0;Laser,0,1,2;League,2,-1,2;Magical,0,3,0;MartialArts,3,0,0;Masterized,3,3,3;Medieval,1,2,0;Mega,2,2,2;Midnight,1,0,2;Missile,0,2,1;Newgen,1,0,2;Nightmare,1,2,0;Ninja,2,1,0;Of the Dead,2,1,0;Old,0,2,1;Operations,1,2,0;Overdrive,1,0,2;Patrol,2,1,0;Pentacle,1,2,0;Pilot,0,0,3;Platform,0,6,0;Police,0,1,2;Princess,3,3,3;Prophecy,1,2,0;Protectors,1,2,0;Puzzle,0,3,0;Quest,1,2,0;Radical,2,0,1;Rage,2,0,1;Raider,1,2,0;Rampage,2,0,1;Reactor,0,1,2;RealSports,1,0,2;Reloaded,2,2,2;Rider,0,0,3;Room,0,3,0;Running,0,2,1;Screaming,2,0,1;Secret,1,2,0;Sexy,3,3,3;Shining,2,0,1;Sky,0,1,2;Space,0,3,0;Speed,0,0,3;Sport,0,1,2;Star,0,2,1;Strategic,-1,3,1;Street,2,0,1;Strike,1,2,0;Super,2,2,2;SuperJump,1,2,0;Sword,1,2,0;The Return,2,2,2;Tournament,2,0,1;Track,0,1,2;TreasureHunt,0,3,0;Triple,3,3,3;Trouble,2,2,2;Turbo,0,0,3;Ultimate,3,3,3;Ultra,2,2,2;Universal,1,0,2;Unleashed,2,1,0;Vanguard,2,1,0;Warlord,2,1,0;Warrior,1,2,0;Warzone,2,1,0;Wing,0,1,2;Worldwide,1,0,2;Xeno,2,1,0;K-2000,0,0,3;Zero,0,1,2;Wicked,1,0,2;Keeper,1,2,0;Versus,2,0,1;Brutal,3,0,0;Lightning,0,0,3;Cyber,0,1,2;Evolution,1,0,2;Shadow,1,1,1;AAaAaAAAH,3,3,3;International,1,0,2;Rally,0,0,3;Vortex,0,1,2;Roadtrip,0,1,2";

    void Awake()
    {
        //Debug.Log("DATA AWAKE");
        wordList = new List<Word>();
        ReadCSVFile();
    }

    void ReadCSVFile()
    {
        /*
        try
        {
            using(StreamReader strReader = new StreamReader(Application.streamingAssetsPath + "/data.csv"))
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
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        */

        string[] dataCsv = csv.Split(";");
        foreach(string line in dataCsv){
            string[] dataValues = line.Split(',');
            Word word = new Word(dataValues[0], int.Parse(dataValues[1]), int.Parse(dataValues[2]), int.Parse(dataValues[3]));
            wordList.Add(word);
        }

        /*
        wordList.ForEach(word => {
            Debug.Log("Word : " + word.label + ", " + word.versusValue.ToString() + ", " + word.platformValue.ToString() + ", " + word.racingValue.ToString());
        });
        */
    }
}
