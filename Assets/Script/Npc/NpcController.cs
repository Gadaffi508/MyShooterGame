using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NpcController : MonoBehaviour
{
    public Transform[] Paths;

    private int index = 0;
    private NavMeshAgent agent;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        NpcPathFollow();
        anim.SetFloat("speed",agent.velocity.magnitude);
    }

    private void NpcPathFollow()
    {
        if (NpcTurn())
        {
            index++;
        }
        
        
        if (index == 4)
        {
            index = 0;
        }
        
        agent.SetDestination(Paths[index].position);
    }

    private Vector3 PathCurrentPos() => new Vector3(Paths[index].position.x,transform.position.y,Paths[index].position.z);

    private bool NpcTurn()
    {
        if (transform.position == PathCurrentPos())
        {
            return true;
        }
        else return false;
    }
}
