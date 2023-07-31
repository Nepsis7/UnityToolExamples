using System.Collections.Generic;
using UnityEngine;
using SF = UnityEngine.SerializeField;

public class ExampleScript : MonoBehaviour
{
    [SF] bool exampleBool;
    [SF] float exampleFloat;
    [SF] Vector3 exampleVector3;
    [SF] List<float> exampleList;
    bool exampleNonSerializedBool;
#if UNITY_EDITOR
    public bool ExampleNonSerializedBool { get => exampleNonSerializedBool; set => exampleNonSerializedBool = value; }
#endif
}
