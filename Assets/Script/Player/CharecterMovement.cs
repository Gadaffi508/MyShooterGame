using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CharecterMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float SlowSpeed;
    [SerializeField] private float jumpforce;

    float X, Z;
    bool jump = false;
    float idleTime;

    Rigidbody rb;
    Animator anim;
    Vector3 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        Animations();

        if (Input.GetKeyDown(KeyCode.Space) && jump == true) Jump();

        if (idleTime >= 13) idleTime = 0;

        movement = Camera.main.transform.forward * Z + Camera.main.transform.right * X;
        movement.y = 0;

        SlowWalk();
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
            anim.SetBool("jump", false);
        }
    }

    public void Animations()
    {
        anim.SetFloat("speed", rb.velocity.magnitude);
        idleTime += Time.deltaTime;
        anim.SetFloat("idleTime", idleTime);
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        jump = false;
        anim.SetBool("jump", true);
    }

    public void SlowWalk()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) { anim.SetBool("Sspeed", true); speed = SlowSpeed; }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) { anim.SetBool("Sspeed", false); speed = 2f; }
    }
}
