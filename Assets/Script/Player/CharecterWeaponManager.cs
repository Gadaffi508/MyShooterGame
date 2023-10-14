using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterWeaponManager : MonoBehaviour
{
    [SerializeField] private Transform leftHand;
    [SerializeField] private LineRenderer leftHandLineRenderer;
    [SerializeField] private Transform rightHand;
    [SerializeField] private LineRenderer rightHandLineRenderer;
    [SerializeField] private float handAttackLength;
    [SerializeField] private KeyCode SlowModKey;
    [SerializeField] private float SlowTimeScale;

    bool open;
    float startFixedTimeStep;
    float standartspeed;

    Animator anim;
    CharecterMovement charecterMovement;

    private void Start()
    {
        startFixedTimeStep = Time.fixedDeltaTime;
        anim = GetComponent<Animator>();
        charecterMovement = GetComponent<CharecterMovement>();
        standartspeed = charecterMovement.speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(SlowModKey))
        {
            open = !open;
            if (open) SetTimeScale(SlowTimeScale);
            else SetTimeScale(1);
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("MagicA");
            charecterMovement.speed = 0;
        }
    }

    private void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = timeScale * startFixedTimeStep;
    }

    public void AttackAnimFunc()
    {
        charecterMovement.speed = standartspeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(leftHand.position,HandPos(leftHand));
        Gizmos.DrawLine(rightHand.position, HandPos(rightHand));
    }

    private Vector3 HandPos(Transform Hand)
    {
        Vector3 handP = Hand.position;
        Vector3 handForward = Hand.forward;
        handForward.y = 0;
        handForward.Normalize();
        Vector3 _offset = handForward * handAttackLength;
        return handP + _offset;
    }

    public void Attack()
    {
        //-----Line is Active
        leftHandLineRenderer.enabled = true;
        rightHandLineRenderer.enabled = true;
        //-----Left Hand
        leftHandLineRenderer.SetPosition(0,leftHand.position);
        leftHandLineRenderer.SetPosition(1,HandPos(leftHand));
        //-----Right Hand
        rightHandLineRenderer.SetPosition(0, rightHand.position);
        rightHandLineRenderer.SetPosition(1, HandPos(rightHand));
    }

    public void AfterAttack()
    {
        leftHandLineRenderer.enabled = false;
        rightHandLineRenderer.enabled = false;
    }
}
