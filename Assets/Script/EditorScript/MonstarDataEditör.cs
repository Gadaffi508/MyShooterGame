using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EditorData))]
public class MonstarDataEditör : Editor
{
    public override void OnInspectorGUI()
    {
        EditorData data = (EditorData)target;
        
        EditorGUILayout.LabelField(data.name.ToUpper(), EditorStyles.boldLabel);
        
        EditorGUILayout.Space(10);
        
        //difficulty bar
        float difficulty = data.Health + data.Damage + data.Speed;
        ProgressBar(difficulty / 100,"Difficulty");
        
        //add before
        base.OnInspectorGUI();
        //add after
        EditorGUILayout.LabelField("- - - - - - - -");
    }

    void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect,value,label);
        EditorGUILayout.Space(10);
    }
}
