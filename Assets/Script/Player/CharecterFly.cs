using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterFly : MonoBehaviour
{
    [SerializeField] private KeyCode FlyInput;
    [SerializeField] private float speed;
    [SerializeField] private GameObject ThirdPersonCam;

    CharecterWeaponManager weaponManager;
    CharecterMovement charecterMovement;
    Rigidbody rb;
    Animator anim;

    float X, Z;
    Vector3 movement;
    public bool flying;

    private void Start()
    {
        weaponManager = GetComponent<CharecterWeaponManager>();
        charecterMovement = GetComponent<CharecterMovement>();

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(FlyInput)) Fly();

        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        movement = Camera.main.transform.forward * Z + Camera.main.transform.right * X;
    }

    private void Fly()
    {
        flying = !flying;
        if (flying) anim.SetTrigger("Fly");

        rb.useGravity = !flying;
        anim.SetBool("Fly›", flying);

        weaponManager.enabled = !flying;
        charecterMovement.enabled = !flying;
    }

    private void FixedUpdate()
    {
        if (flying)
        {
            if (movement == Vector3.zero) return;

            Quaternion targetRotation = Quaternion.LookRotation(movement);

            targetRotation = Quaternion.RotateTowards(transform.rotation,targetRotation,90* Time.fixedDeltaTime);

            rb.MoveRotation(targetRotation);

            rb.velocity = new Vector3(movement.normalized.x * speed,movement.normalized.y * speed,movement.normalized.z * speed);
        }
    }
}
