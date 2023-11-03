using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NpcController : MonoBehaviour
{
    public float WalkTime;
    
    private NavMeshAgent agent;
    private Animator anim;
    private Rigidbody rb;

    private float time;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (WalkTimeBool()) RandomWalk();
        
        anim.SetFloat("speed",agent.velocity.magnitude);
    }

    private void RandomWalk() => agent.SetDestination(RandomPos());
    
    private float RandomValue() => Random.Range(0,30);
    private Vector3 RandomPos() => new Vector3(RandomValue() ,transform.position.y,RandomValue() );

    private bool WalkTimeBool()
    {
        if (WalkTime < time)
        {
            time = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
