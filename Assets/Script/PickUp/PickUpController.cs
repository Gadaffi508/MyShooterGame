using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Transform holdArea;
    public float pickUpRange = 5;
    public float pickUpForce = 150;

    private Rigidbody heldObjRb;
    private GameObject heldObj;

    RaycastHit hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                if (RayPickUp())
                {
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else DropObject();
        }

        if(heldObj != null) MoveObject();
    }

    void MoveObject()
    {
        if (MoveBool()) heldObjRb.AddForce(MoveDirection() * pickUpForce);
    }

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRb = pickObj.GetComponent<Rigidbody>();
            heldObjRb.useGravity = false;
            heldObjRb.drag = 10;
            heldObjRb.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRb.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        heldObjRb.useGravity = true;
        heldObjRb.drag = 1;
        heldObjRb.constraints = RigidbodyConstraints.None;

        heldObjRb.transform.parent = null;
        heldObj = null;
    }

    private bool MoveBool() => Vector3.Distance(heldObj.transform.position,holdArea.position) > 0.1f;

    private bool RayPickUp() => Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, pickUpRange);

    private Vector3 MoveDirection() => (holdArea.position - heldObj.transform.position);
}
