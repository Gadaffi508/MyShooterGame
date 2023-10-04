using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrstPersonCam : MonoBehaviour
{
    public GameObject ThirdPersonCam;
    public Transform Player;
    public float mouseSensivity = 100;

    float cameraVerticalRotation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ThirdPersonCam.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        float InputX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float InputY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        cameraVerticalRotation -= InputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -60f,80f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        Player.Rotate(Vector3.up * InputX);
    }
}
