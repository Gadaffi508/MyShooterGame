using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        DoorEvents.current.DoorwayTriggerEnter(id);
    }

    private void OnTriggerExit(Collider other)
    {
        DoorEvents.current.DoorwayTriggerExit(id);
    }
}
