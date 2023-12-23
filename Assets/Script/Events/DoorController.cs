using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    
    private void Start()
    {
        DoorEvents.current.OnDoorwayTriggerEnter += OpenDoor;
        DoorEvents.current.OnDoorwayTriggerExit += CloseDoor;
    }

    private void OnDisable()
    {
        DoorEvents.current.OnDoorwayTriggerEnter -= OpenDoor;
        DoorEvents.current.OnDoorwayTriggerExit -= CloseDoor;
    }

    private void OpenDoor(int _id)
    {
        if (id == _id)
        {
            LeanTween.moveLocalY(gameObject, 2.0f, 1).setEaseInQuad();
        }
    }

    private void CloseDoor(int _id)
    {
        if (id == _id)
        {
            LeanTween.moveLocalY(gameObject, .2f, 1).setEaseInOutQuad();
        }
    }
}
