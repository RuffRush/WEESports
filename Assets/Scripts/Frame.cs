using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Frame: MonoBehaviour
{
    int         FirstThrow      { get; set; }
    int         SecondThrow     { get; set; }
    int         FrameTotal      { get; set; }



    public Frame(int firstThrow, int secondThrow)
        {
        this.FirstThrow = firstThrow;
        this.SecondThrow = secondThrow;

        FrameTotal = firstThrow = secondThrow;
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
