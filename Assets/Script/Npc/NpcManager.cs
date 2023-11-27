using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcManager : MonoBehaviour
{
    [SerializeField] private Transform ShopPos;
    [SerializeField] private Transform EndPos;
    [SerializeField] private int talkTime;

    private Animator anim;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
        agent.SetDestination(ShopPos.position);
    }

    private void Update()
    {

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            anim.SetBool("Talk",true);
            StartCoroutine(ExitWalk());
        }
        anim.SetFloat("speed",agent.velocity.magnitude);
    }

    IEnumerator ExitWalk()
    {
        yield return new WaitForSeconds(talkTime);
        anim.SetBool("Talk",false);
        agent.SetDestination(EndPos.position);
    }
}
