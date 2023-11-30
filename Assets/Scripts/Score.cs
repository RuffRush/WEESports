using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;
using TMPro;
using System;

public class Score : MonoBehaviour
    {

    TMP_Text Scoring;

    // Start is called before the first frame update
    void awake()
        {

        }

    // Update is called once per frame
    public static void updateScore(BowlingGame bowlingGame)
        {
        for (int i = 0; i < bowlingGame.frames.Length; i++)
            {



            Debug.Log("Attempt " + i + " - ");
            Debug.Log("[" + bowlingGame.frames[i].getFirstRoll() + " , ");

            if (bowlingGame.frames[i].getIsSpare())
                Debug.Log("\\");

            else if (bowlingGame.frames[i].getIsStrike())
                Debug.Log("X");

            else
                Debug.Log(bowlingGame.frames[i].getSecondRoll());

            Debug.Log("] , Temp: " + bowlingGame.frames[i].getTemp());
            Debug.Log(", Points: " + bowlingGame.frames[i].getPoints());
            Debug.Log("");
        }
        }

    void NewGame()
        {

        }


    }