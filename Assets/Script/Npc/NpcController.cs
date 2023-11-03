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
        if (WalkTime < time)
        {
            RandomWalk();
            time = 0;
        }
        
        anim.SetFloat("speed",agent.velocity.magnitude);
    }

    private void RandomWalk()
    {
        float randomValue = Random.Range(0,30);
        Vector3 randomPos = new Vector3(randomValue,transform.position.y,randomValue);
        agent.SetDestination(randomPos);
    }
}
