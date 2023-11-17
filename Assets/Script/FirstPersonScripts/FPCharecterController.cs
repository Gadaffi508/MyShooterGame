using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCharecterController : MonoBehaviour
{
    public float _Speed = 12f;
    public float jumpForce;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    private Vector3 velocity;
    private CharacterController controller;
    private bool İsGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        İsGrounded = GroundBool();
        
        if (GroundAır()) velocity.y = -2f;

        if (JumpPorperty()) velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        controller.Move(MoveVelocity(x,y) * Time.deltaTime * _Speed);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private bool GroundBool() => Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    private bool GroundAır() => İsGrounded && velocity.y < 0;

    private bool JumpPorperty() => Input.GetKeyDown(KeyCode.Space) && İsGrounded;
    
    private Vector3 MoveVelocity(float x, float y) => transform.right * x + transform.forward * y;
}
