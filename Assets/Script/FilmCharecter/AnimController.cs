using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    private bool walk;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) walk = true;
        if(walk) transform.Translate(0,0,2 * Time.deltaTime);
        anim.SetBool("Walk",walk);
    }
}
