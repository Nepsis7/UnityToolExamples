using UnityEngine;
using UnityEditor;

public class ExampleToolEditorWindow : EditorWindow
{
    Vector3 debugPosition;
    Vector3 debugScale;
    Color debugColor;
    bool debugEnabled;

    [MenuItem("Custom Menu/Custom Submenu/Custom Item")]
    static void OpenWindow()
    {
        GetWindow<ExampleToolEditorWindow>("Custom Title");
    }

    void OnGUI()
    {
        GUILayout.Label("label");
        GUI.enabled = false;
        GUILayout.Button("greyed out button");
        GUI.enabled = true;

        GUI.enabled = debugEnabled = EditorGUILayout.Toggle("debugs", debugEnabled);
        debugPosition = EditorGUILayout.Vector3Field("debug position", debugPosition);
        debugScale = EditorGUILayout.Vector3Field("debug scale", debugScale);
        debugColor = EditorGUILayout.ColorField("debug color", debugColor);
        GUI.enabled = true;

        if (GUILayout.Button("popup"))
            CreateWindow<ExampleToolEditorWindow>("Custom Title");
    }
}
