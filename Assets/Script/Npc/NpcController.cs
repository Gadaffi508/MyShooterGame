using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public Transform target;
    public Transform Head;
    public float maxRotate = 90f;
    public float rotateSpeed;
    
    private NavMeshAgent agent;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        LookPlayer();
    }

    private void LookPlayer()
    {
        if (CurrentRotateAngle() <= maxRotate) Head.rotation = HeadLook();
    }

    private Vector3 TargetDirection() => target.position - Head.position;

    private float CurrentRotateAngle() => Vector3.Angle(transform.forward, TargetDirection());
    
    private Quaternion TargetRotate() => Quaternion.LookRotation(TargetDirection());
    private Quaternion HeadLook() => Quaternion.RotateTowards(Head.rotation, TargetRotate(), Time.deltaTime * rotateSpeed);
}
