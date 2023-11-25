using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorManagers : MonoBehaviour
{
    [SerializeField] private EditorData data;
    [SeperatorAttrib(1,20)]
    [SerializeField] private int Health;
    public EditorData Data => data;

    private void Awake()
    {
        Debug.Log("Data Name : " + data.Name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,data.RangeOfAwarenees);
        
        Gizmos.color = Color.cyan;
        Vector3 ray = transform.forward * data.RangeOfAwarenees;
        Gizmos.DrawRay(transform.position,ray);
    }
}
