using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class LogPerformance
{
    private const string testFilePath = "TestOverview";

    /// <summary>
    /// Logs the given data set to a csv file
    /// </summary>
    /// <param name="pData"></param>
    /// <param name="pFileName">If this parameter is "" it will use the testname of the data set as the file name</param>
    /// <returns></returns>
    public static void LogData(Data pData, string pFileName = "")
    {
        Debug.Log("Start logging data");
        string filePath = "";
        string fileName = "";

        if (pFileName == "")
            fileName = pData.TestName;
        else
            fileName = pFileName;

        filePath = Application.dataPath + "/Tests/" + fileName + ".csv";

        int index = 0;
        while (File.Exists(filePath))
        {
            index++;
            fileName = fileName + index;
            filePath = Application.dataPath + "/Tests/" + fileName + ".csv";
        }

        TextWriter writer = new StreamWriter(filePath, false);
        writer.WriteLine("Frame Number, FPS, Frame Length (seconds)");
        writer.Close();

        writer = new StreamWriter(filePath, true);
        foreach (FrameData data in pData.TestData)
        {
            writer.WriteLine(data.FrameNumber + "," + data.FPS + "," + data.FrameLength);
        }

        writer.Close();

        LogTest(pData);
        Debug.Log("Done logging data");
    }

    private static void LogTest(Data pData)
    {
        Debug.Log("Logging Test");
        string filePath = Application.dataPath + "/Tests/" + testFilePath + ".csv";

        if (!File.Exists(filePath))
        {
            TextWriter writer = new StreamWriter(filePath, false);
            writer.WriteLine("Test Name, Test Description, Frames Recorded, Object Count, Object Type, Collision Type, Average FPS, Average Frame Length");
            writer.Close();
        }

        TextWriter textWriter = new StreamWriter(filePath, true);
        textWriter.WriteLine($"{pData.TestName}, {pData.TestDescription}, {pData.RecordedFrames}, {pData.TotalObjects}, {pData.ObjType}, {pData.CollisionType}, {pData.GetAverageRecordedFPS()}, {pData.GetAverageFrameLength()}");
        textWriter.Close();

        Debug.Log("Done Logging Test");
    }
}
