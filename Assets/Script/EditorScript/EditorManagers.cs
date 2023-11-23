using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorManagers : MonoBehaviour
{
    [SerializeField] private EditorData data;

    private void Awake()
    {
        Debug.Log("Data Name : " + data.Name);
    }
}
