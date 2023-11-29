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
    public static void updateScore()
        {
        for (int i = 0; i < BallDetector.game.frames.Length; i++)
            {

            Debug.Log("Attempt " + i + " - ");
            Debug.Log("[" + BallDetector.game.frames[i].getFirstRoll() + " , ");

            if (BowlingGame.framesStatic[i].getIsSpare())
                Debug.Log("\\");

            else if (BowlingGame.framesStatic[i].getIsStrike())
                Debug.Log("X");

            else
                Debug.Log(BowlingGame.framesStatic[i].getSecondRoll());

            Debug.Log("] , Temp: " + BallDetector.game.frames[i].getTemp());
            Debug.Log(", Points: " + BallDetector.game.frames[i].getPoints());
            Debug.Log("");
        }
        }

    void NewGame()
        {

        }


    }