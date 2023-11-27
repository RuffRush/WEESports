using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Frame: MonoBehaviour
{
public  int         FirstThrow      { get; set; }
public  int         SecondThrow     { get; set; }
public  int         FrameTotal      { get; set; }



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
