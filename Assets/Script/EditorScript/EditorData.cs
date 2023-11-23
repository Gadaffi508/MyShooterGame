using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Editor Data",menuName = "UnitData/Editor")]
public class EditorData : ScriptableObject
{
    [Header("General Stats")] [SerializeField] [TextArea]
    private string _name;

    [SerializeField] [Range(0, 100)] private float _changeToDropItem;

    [SerializeField] [Tooltip("Radius size where monster will see the player")]
    private float _rangeOfAwarenees;

    [SerializeField] private EditorType _editorType = EditorType.None;

    public string Name => _name;
    public float ChangeToDropItem => _changeToDropItem;
    public float RangeOfAwarenees => _rangeOfAwarenees;
    public EditorType EditorType => _editorType;
}
