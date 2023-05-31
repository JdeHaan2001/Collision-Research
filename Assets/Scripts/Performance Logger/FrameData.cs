using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameData
{
    public int FrameNumber;
    public float FPS;
    /// <summary>
    /// Frame length in seconds
    /// </summary>
    public float FrameLength;

    public FrameData(int pFrameNumber, float pFPS, float pframeLength)
    {
        FrameNumber = pFrameNumber;
        FPS = pFPS;
        FrameLength = pframeLength;
    }
}
