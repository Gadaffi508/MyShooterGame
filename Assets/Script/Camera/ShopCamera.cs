using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCamera : MonoBehaviour
{
    public float mouseSensivity = 100;
    public Transform CamPosY;
    
    float cameraVerticalRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        float InputX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float InputY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        transform.localEulerAngles = ToAngles(InputY);
        
        CamPosY.Rotate(Vector3.up * InputX);
    }

    private Vector3 ToAngles(float InputY)
    {
        cameraVerticalRotation -= InputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, 0f,15f);
        Vector3 horY = Vector3.right * cameraVerticalRotation;
        return horY;
    }
}
