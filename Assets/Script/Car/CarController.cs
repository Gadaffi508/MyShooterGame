using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontal, vertical;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    [SerializeField] private WheelCollider frontleftwheelcollider, frontrightwheelcollider;
    [SerializeField] private WheelCollider rearleftwheelcollider, rearrightwheelcollider;

    [SerializeField] private Transform frontleftTransform, frontrightTransform;
    [SerializeField] private Transform rearleftTransform, rearrightTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontleftwheelcollider.motorTorque = vertical * motorForce;
        frontrightwheelcollider.motorTorque = vertical * motorForce;

        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontal;
        frontleftwheelcollider.steerAngle = currentSteerAngle;
        frontrightwheelcollider.steerAngle = currentSteerAngle;
    }

    private void ApplyBreaking()
    {
        frontrightwheelcollider.brakeTorque = currentbreakForce;
        frontleftwheelcollider.brakeTorque = currentbreakForce;
        rearleftwheelcollider.brakeTorque = currentbreakForce;
        rearrightwheelcollider.brakeTorque = currentbreakForce;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheels(frontleftwheelcollider,frontleftTransform);
        UpdateSingleWheels(frontrightwheelcollider,frontrightTransform);
        UpdateSingleWheels(rearrightwheelcollider,rearrightTransform);
        UpdateSingleWheels(rearleftwheelcollider,rearleftTransform);
    }

    private void UpdateSingleWheels(WheelCollider wheel, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheel.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
