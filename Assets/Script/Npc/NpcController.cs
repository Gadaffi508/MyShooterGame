using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public GameObject TalkPressText;
    public GameObject TalkSoundObj;

    private Animator anim;
    private bool Contact;
    private bool İsSpeaking;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Contact) İsSpeaking = true;
        if (!Contact) İsSpeaking = false;
        
        Speak(İsSpeaking);
    }

    private void OnTriggerEnter(Collider other) => TalkObjActive(other,true);

    private void OnTriggerExit(Collider other) => TalkObjActive(other,false);

    private void TalkObjActive(Collider other, bool Active)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TalkPressText.SetActive(Active);
        }

        Contact = Active;
    }
    private void Speak(bool _speak)
    {
        anim.SetBool("Talk",_speak);
        TalkSoundObj.SetActive(_speak);
    }
}
