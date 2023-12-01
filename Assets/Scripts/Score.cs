using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
    {

    [ShowInInspector]
    public static TMP_Text[] firstThrows;
    [ShowInInspector]
    public static TMP_Text[] secondThrows;
    [ShowInInspector]
    public static TMP_Text[] scoreTotals;
    [ShowInInspector]
    public static TMP_Text   points;

    // Start is called before the first frame update
    void Awake()
        {
        for (int i = 0; i < 10; i++)
            {
            firstThrows[i] = GameObject.Find("FirstThrow (" + i + ")").GetComponent<TMP_Text>();
            secondThrows[i] = GameObject.Find("SecondThrow (" + i + ")").GetComponent<TMP_Text>();
            scoreTotals[i] = GameObject.Find("ScoreTotal (" + i + ")").GetComponent<TMP_Text>();
            points = GameObject.Find("Points").GetComponent<TMP_Text>();
            }
        }

    // Update is called once per frame
    public static void updateScore(BowlingGame bowlingGame)
        {
        for (int i = 0; i < bowlingGame.frames.Length; i++)
            {

            if (bowlingGame.frames[i].getFirstRoll()!= -1)
                {
                String logText = "";
                logText += $"Attempt {i} - ";
                logText += $"[ {bowlingGame.frames[i].getFirstRoll()} , ";
                firstThrows[i].SetText("" + bowlingGame.frames[i].getFirstRoll());


                if (bowlingGame.frames[i].getIsSpare())
                    {
                    logText += $"\\";
                    secondThrows[i].SetText("\\");
                    }
                else if (bowlingGame.frames[i].getIsStrike()) {
                    logText += $"X";
                    secondThrows[i].SetText("X");

                    }
                else {
                    logText += $"{bowlingGame.frames[i].getSecondRoll()}";
                    secondThrows[i].SetText(""+bowlingGame.frames[i].getSecondRoll());

                    }
                logText += $"] , Temp: {bowlingGame.frames[i].getTemp()}";

                logText += $", Points: {bowlingGame.frames[i].getPoints()}";
                points.SetText(bowlingGame.frames[i].getPoints() + "");


                Debug.Log(logText);
                }
            }
        }


    void NewGame()
        {

        }


    }