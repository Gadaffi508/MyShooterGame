using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CharecterMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float  jumpforce;
    
    float X, Z;
    bool jump = false;

    Rigidbody rb;
    Animator anim;
    Vector3 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        //anim.SetFloat("Speed", (Mathf.Abs(X) + Mathf.Abs(Z)));

        if (Input.GetKeyDown(KeyCode.Space) && jump == true)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            jump = false;
        }
        movement = Camera.main.transform.forward * Z + Camera.main.transform.right * X;
        movement.y = 0;
    }
    private void FixedUpdate()
    {
        if (movement == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(movement);

        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

        rb.velocity = new Vector3(movement.normalized.x * speed, rb.velocity.y, movement.normalized.z * speed);

        rb.MoveRotation(targetRotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = true;
        }
    }
}
