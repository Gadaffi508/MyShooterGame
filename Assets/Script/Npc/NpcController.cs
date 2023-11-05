using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NpcController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private int index = 0;

    public Transform[] paths;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
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

        if (index==4)
        {
            index = 0;
        }

        agent.SetDestination(paths[index].position);
    }

    private Vector3 PathCurrentPos() => new Vector3(paths[index].position.x,transform.position.y,paths[index].position.z);

    private bool NpcTurn()
    {
        if (transform.position == PathCurrentPos())
        {
            return true;
        }
        else return false;
    }
}
