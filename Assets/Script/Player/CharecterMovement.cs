using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterMovement : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private CharacterController characterController;

    [Header("Values")]
    public float moveSpeed;
    public float JumpHeight;
    public float turnSmooth;

    float turnSmoothVelocity;
    float horizontal, vertical;
    float yVelocity;
    float gravity = -9.81f;

    private void Update()
    {
        MyInput();

        if (characterController.isGrounded)
        {
            yVelocity = -2f;

            if (Input.GetKeyDown(KeyCode.Space)) yVelocity = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
        else yVelocity += gravity * Time.deltaTime;

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        direction.y = yVelocity;

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity, turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            characterController.Move(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void MyInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
}
