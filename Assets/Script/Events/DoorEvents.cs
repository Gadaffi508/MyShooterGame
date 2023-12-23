using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvents : MonoBehaviour
{
    public static DoorEvents current;

    public event Action <int> OnDoorwayTriggerEnter;
    public event Action <int> OnDoorwayTriggerExit;

    private void Awake()
    {
        current = this;
    }

    public void DoorwayTriggerEnter(int id)
    {
        OnDoorwayTriggerEnter?.Invoke(id);
    }

    public void DoorwayTriggerExit(int id)
    {
        OnDoorwayTriggerExit?.Invoke(id);
    }
}
