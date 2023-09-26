using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Frames : Frame
{
    Frame[] frameArray = new Frame[10];

    void AddFrameScore(int frameNum, int firstThrow, int secondThrow)
        {
        frameArray[frameNum] = new Frame(firstThrow, secondThrow);
        }
}
