using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CharecterMovement : CharecyerMove
{
    
    [SerializeField] private float SlowSpeed;
    [SerializeField] private float jumpforce;

    bool jump = false;
    float idleTime;

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

    public override void ÝsUpdate()
    {
        DancAnim();

        Animations();

        if (Input.GetKeyDown(KeyCode.Space) && jump == true) Jump();

        if (idleTime >= 13) idleTime = 0;

        SlowWalk();

        FastRun();
    }

    public override void ÝsStart()
    {
        rb.freezeRotation = true;
    }
}
