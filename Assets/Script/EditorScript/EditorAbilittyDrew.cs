using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EditorAbility))]
public class EditorAbilittyDrew : PropertyDrawer
{
    private SerializedObject name;
    private SerializedObject _damage;
    private SerializedObject _type;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        Rect foldOutBox = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);

        property.isExpanded = EditorGUI.Foldout(foldOutBox,property.isExpanded,label);

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int totalLines = 1;

        if (property.isExpanded)
        {
            totalLines += 3;
        }

        return (EditorGUIUtility.singleLineHeight * totalLines);
    }
}
