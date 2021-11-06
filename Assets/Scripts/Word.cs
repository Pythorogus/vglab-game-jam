using System;
public class Word
{
    public string label =  "";
    public int versusValue = 0;
    public int platformValue = 0;
    public int racingValue = 0;

    public Word(string newLabel, int newVersusValue, int newPlatformValue, int newRacingValue){
        label = newLabel;
        versusValue = newVersusValue;
        platformValue = newPlatformValue;
        racingValue = newRacingValue;
    }
}
