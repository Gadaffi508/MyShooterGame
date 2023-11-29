using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcManager : MonoBehaviour
{
    [SerializeField] private Transform ShopPos;
    [SerializeField] private Transform EndPos;

    private Animator anim;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        ShopPos = GameObject.FindGameObjectWithTag("Shop").transform;
        EndPos = GameObject.FindGameObjectWithTag("End").transform;
        
        agent.SetDestination(ShopPos.position);
    }

    private void Update()
    {
        if (NpcComeShop()) anim.SetBool("Talk",true);
        
        anim.SetFloat("speed",agent.velocity.magnitude);
        
        if(NpcComeShop() && Input.GetKeyDown(KeyCode.E)) ExitWalk();
    }

    private void ExitWalk()
    {
        anim.SetBool("Talk",false);
        agent.SetDestination(EndPos.position);
    }

    private bool NpcComeShop() => agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending;
}
