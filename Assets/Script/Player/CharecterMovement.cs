using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CharecterMovement : MonoBehaviour
{
    [SerializeField, Tooltip("Move speed")] private float speed;
    [SerializeField] private float SlowSpeed;
    [SerializeField] private float jumpforce;
    [SerializeField] private GameObject ThirdPersonCam;

    float X, Z;
    bool jump = false;
    float idleTime;

    Rigidbody rb;
    Animator anim;
    Vector3 movement;

    private bool Cam›sActive() => ThirdPersonCam.activeSelf;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        DancAnim();

        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        Animations();

        if (Input.GetKeyDown(KeyCode.Space) && jump == true) Jump();

        if (idleTime >= 13) idleTime = 0;

        movement = Camera.main.transform.forward * Z + Camera.main.transform.right * X;
        movement.y = 0;

        SlowWalk();

        FastRun();
    }
    private void FixedUpdate()
    {
        if (movement == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(movement);

        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

        rb.velocity = new Vector3(movement.normalized.x * speed, rb.velocity.y, movement.normalized.z * speed);

        if(Cam›sActive()) rb.MoveRotation(targetRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = true;
            anim.SetBool("jump", false);
        }
    }

    private void Animations()
    {
        anim.SetFloat("speed", rb.velocity.magnitude);
        idleTime += Time.deltaTime;
        anim.SetFloat("idleTime", idleTime);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        jump = false;
        anim.SetBool("jump", true);
    }

    private void SlowWalk()
    {
        if (Input.GetKeyDown(KeyCode.C)) { anim.SetBool("Sspeed", true); speed = SlowSpeed; }
        else if (Input.GetKeyUp(KeyCode.C)) { anim.SetBool("Sspeed", false); speed = 2f; }
    }

    private void FastRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) { anim.SetBool("Shift", true); StartCoroutine(DelaySpeed(10,.2f)); }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) { anim.SetBool("Shift", false); StartCoroutine(DelaySpeed(1.5f,.3f)); }
    }

    private void DancAnim()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { anim.SetBool("Dance", true); anim.SetFloat("Number", 1); };
        if (Input.GetKeyUp(KeyCode.Alpha1)) anim.SetBool("Dance", false);
        if (Input.GetKeyDown(KeyCode.Alpha2)) { anim.SetBool("Dance", true); anim.SetFloat("Number", 2); };
        if (Input.GetKeyUp(KeyCode.Alpha2)) anim.SetBool("Dance", false);
        if (Input.GetKeyDown(KeyCode.Alpha3)) { anim.SetBool("Dance", true); anim.SetFloat("Number", 3); };
        if (Input.GetKeyUp(KeyCode.Alpha3)) anim.SetBool("Dance", false);
    }

    IEnumerator DelaySpeed(float _speed,float time)
    {
        yield return new WaitForSeconds(time);
        speed = _speed;
    }
}
