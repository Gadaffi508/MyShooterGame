using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCharecterController : MonoBehaviour
{
    public float _speed;
    public float jumpForce;
    
    private Rigidbody rb;
    private float X, Y;

    private bool jump;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && jump)
        {
            rb.AddForce(Vector3.up* jumpForce * Time.deltaTime);
            jump = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = MoveVelocity();
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = true;
        }
    }

    private Vector3 MoveVelocity() => new Vector3(X * Time.deltaTime * _speed,rb.velocity.y,Y * Time.deltaTime * _speed);
}
