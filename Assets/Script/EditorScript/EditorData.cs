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

    [SerializeField] private bool _canEnterCombat = true;

    [SerializeField] private EditorType _editorType = EditorType.None;

    [SerializeField] private float _Health;
    [SerializeField] private float _Damage;
    [SerializeField] private float _Speed;

    public string Name => _name;
    public float ChangeToDropItem => _changeToDropItem;
    public float RangeOfAwarenees => _rangeOfAwarenees;
    public bool CanEnterCombat => _canEnterCombat;
    public EditorType EditorType => _editorType;

    public float Health => _Health;
    public float Damage => _Damage;
    public float Speed => _Speed;
}
