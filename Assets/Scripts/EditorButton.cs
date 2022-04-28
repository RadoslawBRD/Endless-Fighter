using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class EditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameManager myScript = (GameManager)target;
        if (GUILayout.Button("Spawn"))
        {
            myScript.CreateEnemy();
        }
    }

}