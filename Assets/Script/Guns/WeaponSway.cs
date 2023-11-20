using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float smooth;
    public float swayMultiplier;

    private Quaternion inital;
    private Animator anim;
    private void Start()
    {
        inital = transform.localRotation;

        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotaion = inital * rotationX * rotationY;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotaion, smooth * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F)) anim.SetTrigger("RotateG");
        if (Input.GetKeyDown(KeyCode.H)) anim.SetTrigger("RotateH");
        if (Input.GetKeyDown(KeyCode.G)) anim.SetTrigger("LookG");
    }
}
