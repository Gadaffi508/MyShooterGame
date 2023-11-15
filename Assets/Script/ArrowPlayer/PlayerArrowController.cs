using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float jumpDelay;
    
    private Rigidbody rb;
    private Animator anim;
    private float X, Y;
    private bool jump = true;
    private Vector3 movement;
    private Quaternion targetRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && jump == true)
        {
            rb.AddForce(transform.up * jumpForce);
            jump = false;
        }
        
        movement = Camera.main.transform.forward * Y + Camera.main.transform.right * X;
        movement.y = 0;
    }

    private void FixedUpdate()
    {
        if(movement != Vector3.zero) targetRotation = Quaternion.LookRotation(movement);

        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);
        
        rb.MoveRotation(targetRotation);
        
        rb.velocity = new Vector3(movement.normalized.x * Time.deltaTime * speed,rb.velocity.y,movement.normalized.z*Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(delaySpace());
        }
    }

    IEnumerator delaySpace()
    {
        yield return new WaitForSeconds(jumpDelay);
        jump = true;
    }
}
