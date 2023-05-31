using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TestManager))]
public class PerformanceDisplay : MonoBehaviour
{
    [SerializeField]
    private ObjectSpawner objSpawner;
    [SerializeField]
    private TextMeshProUGUI fpsText;
    [SerializeField]
    private TextMeshProUGUI averageFPSText;
    [SerializeField]
    private TextMeshProUGUI frameCountText;
    [SerializeField]
    private TextMeshProUGUI objectTypeText;
    [SerializeField]
    private TextMeshProUGUI objectCountText;
    [SerializeField]
    private TextMeshProUGUI isRecordingText;
    [SerializeField]
    private TextMeshProUGUI totalRecordedFramesText;
    [SerializeField]
    private TextMeshProUGUI collisionTypeText;

    private TestManager frameRate;

    private void Start()
    {
        frameRate = GetComponent<TestManager>();

        if (frameRate == null)
            Debug.LogError("FrameRate component not found", this);

        frameRate.OnStartRecording += StartRecording;
        frameRate.OnStopRecording += StopRecording;
    }

    private void LateUpdate()
    {
        UpdateFPSCounter();
    }

    private void UpdateFPSCounter()
    {
        fpsText.text = frameRate.currentFPS.ToString();
        averageFPSText.text = frameRate.GetAverageFPS().ToString();
        frameCountText.text = frameRate.TotalFrameCount.ToString();
        objectTypeText.text = objSpawner.ObjType.ToString();
        objectCountText.text = objSpawner.AmountOfObjects.ToString();
        totalRecordedFramesText.text = frameRate.totalRecordedFrames.ToString();
        collisionTypeText.text = objSpawner.CollisionType.ToString();
    }

    private void StartRecording()
    {
        isRecordingText.color = Color.green;
        isRecordingText.text = frameRate.IsRecording.ToString();
    }

    private void StopRecording()
    {
        isRecordingText.color = Color.red;
        isRecordingText.text = frameRate.IsRecording.ToString();
    }
}
