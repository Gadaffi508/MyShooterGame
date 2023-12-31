using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;

[CustomEditor(typeof(EditorData))]
public class MonstarDataEditör : Editor
{
    private SerializedProperty _Health;
    private SerializedProperty _Damage;
    private SerializedProperty _Speed;
    private SerializedProperty _abilities;

    private void OnEnable()
    {
        _Health = serializedObject.FindProperty("_Health");
        _Damage = serializedObject.FindProperty("_Damage");
        _Speed = serializedObject.FindProperty("_Speed");

        _abilities = serializedObject.FindProperty("_abilities");
    }

    public override void OnInspectorGUI()
    {
        EditorData data = (EditorData)target;
        
        EditorGUILayout.LabelField(data.name.ToUpper(), EditorStyles.boldLabel);
        
        EditorGUILayout.Space(10);
        
        //difficulty bar
        float difficulty = data.Health + data.Damage + data.Speed;
        ProgressBar(difficulty / 100,"Difficulty");

        if (GUILayout.Button("Random stats"))
        {
            RandomStats(data);
        }

        //EditorGUILayout.BeginHorizontal();
        //EditorGUILayout.labelWidth();    
        //EditorGUILayout.EndHorizontal();    
        
        //add before
        base.OnInspectorGUI();
        //add after
        EditorGUILayout.LabelField("- - - - - - - -");

        if (data.Name == string.Empty)
        {
            EditorGUILayout.HelpBox("Caution : No name specified. Please name the monster!",MessageType.Warning);
        }
        
        if (data.EditorType == EditorType.None)
        {
            EditorGUILayout.HelpBox("No MonsterType selected",MessageType.Warning);
        }
    }

    void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect,value,label);
        EditorGUILayout.Space(10);
    }

    void RandomStats(EditorData data)
    {
        data.MapLength = Random.Range(1,50);
    }
}
