using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrdPersonCam : MonoBehaviour
{
    private const float YMin = -50f;
    private const float YMax = 50f;

    public GameObject FirstsPersonCam;
    public GameObject CursorI;
    public Transform lookAt;
    public Transform Player;
    public float distance;
    public float sensitivity;

    private float currentX = 0;
    private float currentY = 25;

    CharecterFly charecterFly;

    private void Start()
    {
        charecterFly = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<CharecterFly>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && !charecterFly.flying)
        {
            FirstsPersonCam.SetActive(true);
            CursorI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        currentY = Mathf.Clamp(currentY, YMin, YMax);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
        Vector3 direction = new Vector3(0, 0, -distance);
        transform.position = lookAt.position + rotation * direction;

        transform.LookAt(lookAt.position);
    }
}
