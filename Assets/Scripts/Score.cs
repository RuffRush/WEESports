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
    void Update()
        {
        for (int i = 0; i < BallDetector.game.frames.Length; i++)
            {

            Console.WriteLine("Attempt " + i + " - ");
            Console.WriteLine("[" + BallDetector.game.frames[i].getFirstRoll() + " , ");

            if (BowlingGame.framesStatic[i].getIsSpare())
                Console.WriteLine("\\");

            else if (BowlingGame.framesStatic[i].getIsStrike())
                Console.WriteLine("X");

            else
                Console.WriteLine(BowlingGame.framesStatic[i].getSecondRoll());

            Console.WriteLine("] , Temp: " + BallDetector.game.frames[i].getTemp());
            Console.WriteLine(", Points: " + BallDetector.game.frames[i].getPoints());
            Console.WriteLine();
        }
        }

    void NewGame()
        {

        }


    }