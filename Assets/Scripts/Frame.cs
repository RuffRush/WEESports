using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Frame: MonoBehaviour
{
public static int         FirstThrow      { get; set; }
public static int         SecondThrow     { get; set; }
public static int         FrameTotal      { get; set; }



    public Frame(int firstThrow, int secondThrow)
        {
        FirstThrow = firstThrow;
        SecondThrow = secondThrow;

        FrameTotal = firstThrow = secondThrow;
        }

    public Frame(int firstThrow)
        {
        FirstThrow = firstThrow;
        SecondThrow = 0;
        }

    public Frame()
        {
        FirstThrow = 0;
        SecondThrow = 0;
        FrameTotal = 0;
        }

    private void Update()
    {
        
    }
}
