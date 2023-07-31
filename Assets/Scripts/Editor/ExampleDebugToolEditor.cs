using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ExampleDebugTool))]
public class ExampleDebugToolEditor : Editor
{
    Vector3 debugPosition;
    float debugScale = 1f;
    Color debugColor= Color.green;
    bool drawDebugs;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUI.enabled = drawDebugs = EditorGUILayout.Toggle("debugs", drawDebugs);
        debugPosition = EditorGUILayout.Vector3Field("debug position", debugPosition);
        debugScale = EditorGUILayout.FloatField("debug scale", debugScale);
        debugColor = EditorGUILayout.ColorField("debug color", debugColor);
        GUI.enabled = true;
        SceneView.RepaintAll();
    }

    void OnSceneGUI()
    {
        if (!drawDebugs)
            return;
        Handles.color = debugColor;
        Handles.DrawSolidDisc(debugPosition, Vector3.up, debugScale);
    }
}
