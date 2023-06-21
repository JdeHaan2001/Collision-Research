using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public string TestName { get; private set; }
    public string TestDescription { get; private set; }
    public int RecordedFrames { get; private set; }
    public int TotalObjects { get; private set; }
    public ObjectType ObjType { get; private set; }
    public CollisionType CollisionType { get; private set; }

    public List<FrameData> TestData = new List<FrameData>();

    public Data(string pName, string pDescription, int pRecordedFrames, int pObjCount, ObjectType pType, CollisionType pColType, List<FrameData> pData)
    {
        TestName = pName;
        TestDescription = pDescription;
        RecordedFrames = pRecordedFrames;
        TotalObjects = pObjCount;
        ObjType = pType;
        CollisionType = pColType;
        TestData = pData;
    }

    /// <summary>
    /// Returns the average FPS of the test
    /// </summary>
    /// <returns></returns>
    public float GetAverageRecordedFPS()
    {
        float totalFPS = 0;

        foreach (FrameData data in TestData)
            totalFPS += data.FPS;

        return totalFPS / TestData.Count;
    }

    /// <summary>
    /// Returns the average frame length of the test in seconds
    /// </summary>
    /// <returns></returns>
    public float GetAverageFrameLength()
    {
        float totalFrameLength = 0;

        foreach (FrameData data in TestData)
            totalFrameLength += data.FrameLength;

        return totalFrameLength / TestData.Count;
    }
}
