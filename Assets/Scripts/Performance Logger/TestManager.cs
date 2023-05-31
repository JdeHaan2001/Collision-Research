using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TestManager : MonoBehaviour
{
    [SerializeField]
    private ObjectSpawner objSpawner;
    [SerializeField]
    private string TestName;
    [SerializeField]
    private string TestDescription;
    [SerializeField]
    private float TestLengthInFrames;

    public bool IsRecording { get; private set; }
    public float currentFPS { get; private set; }
    public int TotalFrameCount { get; private set; }
    public int totalRecordedFrames { get; private set; }
    public float totalFPS { get; private set; }

    private List<FrameData> frameData = new List<FrameData>();

    public event Action OnStartRecording;
    public event Action OnStopRecording;
    public event Action OnFrameLog;

    private void Start()
    {
        if (objSpawner == null)
            Debug.LogError("ObjSpawner is NULL", this);

        IsRecording = false;
    }

    private void Update()
    {
        TotalFrameCount++;
        currentFPS = 1f / Time.unscaledDeltaTime;
        totalFPS += currentFPS;

        if (IsRecording)
            LogFPS();
    }

    public void StartRecordingCoroutine() => StartCoroutine(StopTestAfterXSeconds());

    private void StartRecording()
    {
        if (TestName == string.Empty || TestName == "")
        {
            Debug.LogWarning("Can't start recording, no test name is given", this);
            return;
        }

        Debug.Log("Start Recording");
        IsRecording = true;
        totalRecordedFrames = 0;
        OnStartRecording?.Invoke();
    }

    public void StopRecording()
    {
        Debug.Log("Stop Recording");
        IsRecording = false;
        OnStopRecording?.Invoke();

        Data data = new Data(TestName, TestDescription, totalRecordedFrames, objSpawner.AmountOfObjects, objSpawner.ObjType, objSpawner.CollisionType, frameData);
        LogPerformance.LogData(data);
    }

    public float GetAverageFPS() => totalFPS / TotalFrameCount;

    private void LogFPS()
    {
        if (currentFPS == 0) return;
        totalRecordedFrames++;

        frameData.Add(new FrameData(totalRecordedFrames, currentFPS, Time.unscaledDeltaTime));
        OnFrameLog?.Invoke();
    }

    public IEnumerator StopTestAfterXSeconds()
    {
        StartRecording();

        int index = 0;
        while (index < TestLengthInFrames)
        {
            yield return new WaitForEndOfFrame();
            index++;
        }

        StopRecording();
    }
    
}
