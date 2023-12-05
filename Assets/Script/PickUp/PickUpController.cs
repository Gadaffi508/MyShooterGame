using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Transform holdArea;

    private GameObject heldObj;
    private Rigidbody heldobjRb;

    public float pickUpRange = 5;
    public float pickUpForce = 150;

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

        if (heldObj != null) MoveObject();
    }

    void MoveObject()
    {

        if (MoveBool()) heldobjRb.AddForce(MoveDirection() * pickUpForce);
    }

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldobjRb = pickObj.GetComponent<Rigidbody>();
            heldobjRb.useGravity = false;
            heldobjRb.drag = 10;
            heldobjRb.constraints = RigidbodyConstraints.FreezeRotation;

            heldobjRb.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        heldobjRb.useGravity = true;
        heldobjRb.drag = 1;
        heldobjRb.constraints = RigidbodyConstraints.None;

        heldobjRb.transform.parent = null;
        heldObj = null;
    }

    private bool MoveBool() => Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f;

    private bool RayPickUp() => Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange);

    private Vector3 MoveDirection() => (holdArea.position - heldObj.transform.position);
}
