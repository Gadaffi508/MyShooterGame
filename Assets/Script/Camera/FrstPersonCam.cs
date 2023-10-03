using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrstPersonCam : MonoBehaviour
{
    public GameObject ThirdPersonCamera;
    public Transform Player;
    public float mouseSensivity = 100;

    float cameraVeticalRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            ThirdPersonCamera.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        float InputX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float InputY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        cameraVeticalRotation -= InputY;
        cameraVeticalRotation = Mathf.Clamp(cameraVeticalRotation, -60f, 80f);
        transform.localEulerAngles = Vector3.right * cameraVeticalRotation;

        Player.Rotate(Vector3.up * InputX);
    }
}
