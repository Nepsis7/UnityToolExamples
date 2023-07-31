using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ExampleScript))]
public class ExampleScriptEditor : Editor
{
    ExampleScript targetObject;
    SerializedProperty exampleBool;
    SerializedProperty exampleFloat;
    SerializedProperty exampleVector3;
    SerializedProperty exampleList;
    bool hideExampleList = true;
    void OnEnable()
    {
        targetObject = target as ExampleScript;
        //targetObject = serializedObject.targetObject as ExampleScript;
        exampleBool = serializedObject.FindProperty("exampleBool");
        exampleFloat = serializedObject.FindProperty("exampleFloat");
        exampleVector3 = serializedObject.FindProperty("exampleVector3");
        exampleList = serializedObject.FindProperty("exampleList");
    }

    public override void OnInspectorGUI()
    {
        //serializedObject.Update();

        targetObject.ExampleNonSerializedBool = EditorGUILayout.Toggle("example non-serialized bool", targetObject.ExampleNonSerializedBool);
        exampleBool.boolValue = EditorGUILayout.Toggle("example bool", exampleBool.boolValue);
        exampleFloat.floatValue = EditorGUILayout.FloatField("example float", exampleFloat.floatValue);
        exampleVector3.vector3Value = EditorGUILayout.Vector3Field("example vector3", exampleVector3.vector3Value);

        GUILayout.BeginHorizontal();
        GUILayout.Label("example list");
        if (GUILayout.Button("+"))
            exampleList.InsertArrayElementAtIndex(0);
        if (GUILayout.Button("x"))
            exampleList.ClearArray();
        if (GUILayout.Button(hideExampleList ? ">" : "v"))
            hideExampleList = !hideExampleList;
        GUILayout.EndHorizontal();
        if (!hideExampleList)
            for (int i = 0; i < exampleList.arraySize; ++i)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(i.ToString());
                SerializedProperty element = exampleList.GetArrayElementAtIndex(i);
                element.floatValue = EditorGUILayout.FloatField("", element.floatValue);
                if (GUILayout.Button("-"))
                {
                    exampleList.DeleteArrayElementAtIndex(i);
                    --i;
                }
                GUILayout.EndHorizontal();
            }

        serializedObject.ApplyModifiedProperties();

        GUILayout.Space(50);

        GUILayout.Label("V default editor V");
        DrawDefaultInspector(); //same as base.OnInspectorGUI()
    }
}
