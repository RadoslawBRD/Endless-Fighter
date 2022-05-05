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
        if (GUILayout.Button("Single Spawn"))
        {
            //myScript.CreateEnemy(true);
        }
        GameManager myScript2 = (GameManager)target;
        if (GUILayout.Button("Auto Spawn"))
        {
            myScript2.SwitchEnemySpawner();
        }
    }
}