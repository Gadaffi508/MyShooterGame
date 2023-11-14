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
    private float X, Y;
    private bool jump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(X * Time.deltaTime * speed,rb.velocity.y,Y*Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {1
            StartCoroutine(delaySpace());
        }
    }

    IEnumerator delaySpace()
    {
        yield return new WaitForSeconds(jumpDelay);
        jump = true;
    }
}
