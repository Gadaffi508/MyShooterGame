using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcManager : MonoBehaviour
{
    public GameObject Sound;

    private Transform ShopPos;
    private Transform EndPos;

    private Animator anim;
    private NavMeshAgent agent;
    private NpcSpawner _spawner;

    private bool NpcController = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        ShopPos = GameObject.FindGameObjectWithTag("Shop").transform;
        EndPos = GameObject.FindGameObjectWithTag("End").transform;

        agent.SetDestination(ShopPos.position);
        
        _spawner = GameObject.FindGameObjectWithTag("Spawner").gameObject.GetComponent<NpcSpawner>();
    }

    private void Update()
    {
        if (NpcİsComeShop() && NpcController==true)
        {
            anim.SetBool("Talk", true);
            Sound.SetActive(true);
        }
        
        anim.SetFloat("speed",agent.velocity.magnitude);

        if (NpcİsComeShop() && Input.GetKeyDown(KeyCode.E)) ExitWalk();
        
        if(NpcİsComeShop() && NpcController == false) Destroy(gameObject,1f);
    }

    private void ExitWalk()
    {
        anim.SetBool("Talk",false);
        Sound.SetActive(false);

        if (NpcController)
        {
            _spawner.SpawnNpc();
            NpcController = false;
        }
        
        agent.SetDestination(EndPos.position);
    }
    
    private bool NpcİsComeShop() => agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending;
}
