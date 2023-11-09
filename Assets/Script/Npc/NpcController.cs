using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NpcController : MonoBehaviour
{
    public GameObject TalkPressObj;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) => TalkObjActive(other,true);

    private void OnTriggerExit(Collider other) => TalkObjActive(other,false);

    private void TalkObjActive(Collider other,bool Active)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TalkPressObj.SetActive(Active);
            if(Input.GetKeyDown(KeyCode.E)) anim.SetBool("Talk",Active);
        }
    }
}
