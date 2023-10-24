using UnityEngine;

public class CharecterFly : CharecyerMove
{
    [SerializeField] private KeyCode FlyInput;
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

    public override float SpeedVar()
    {
        if (charecterMovement.run) speed = 10;
        else if (charecterMovement.slow) speed = .7f;
        else speed = 2;
        return speed;
    }
}
