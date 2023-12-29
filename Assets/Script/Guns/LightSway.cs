using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSway : MonoBehaviour
{
    public float smooth;
    public float swayMultiplier;

    private Quaternion inital;

    private void Start()
    {
        inital = transform.localRotation;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY,Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX,Vector3.up);

        Quaternion targetRotation = inital * rotationX * rotationY;
        transform.localRotation = Quaternion.Lerp(transform.localRotation,targetRotation, smooth * Time.deltaTime);
    }
}
