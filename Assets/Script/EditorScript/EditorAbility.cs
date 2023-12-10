using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElemntType
{
    None,
    Earth,
    Fire,
    Wind,
    Water,
    Heart
}

[System.Serializable]
public class EditorAbility
{
    [SerializeField]
    private string name = "...";
    [SerializeField]
    private int _damage = 1;
    [SerializeField]
    private ElemntType _type = ElemntType.None;
}
