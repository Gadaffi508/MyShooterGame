using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterFly : CharecyerMove
{
    [SerializeField] private KeyCode FlyInput;

    CharecterWeaponManager weaponManager;
    CharecterMovement charecterMovement;

    private void Fly()
    {
        flying = !flying;
        if (flying) anim.SetTrigger("Fly");

        rb.useGravity = !flying;
        anim.SetBool("Fly›", flying);

        weaponManager.enabled = !flying;
        charecterMovement.enabled = !flying;
    }

    public override void ›sUpdate()
    {
        if (Input.GetKeyDown(FlyInput)) Fly();
    }

    public override void ›sStart()
    {
        weaponManager = GetComponent<CharecterWeaponManager>();
        charecterMovement = GetComponent<CharecterMovement>();
    }
}
