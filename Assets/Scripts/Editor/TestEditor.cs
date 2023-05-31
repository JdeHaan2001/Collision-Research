using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestManager))]
public class TestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var testManager = target as TestManager;
        base.OnInspectorGUI();

        if (!Application.isPlaying) return;

        GUILayout.Space(10f);

        if (!testManager.IsRecording)
        {
            if (GUILayout.Button("Start Recording"))
                testManager.StartRecordingCoroutine();
        }
        //else
        //{
        //    if (GUILayout.Button("Stop Recording"))
        //        testManager.StopRecording();
        //}
    }
}
