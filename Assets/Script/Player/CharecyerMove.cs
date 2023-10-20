using UnityEngine;

public abstract class CharecyerMove : MonoBehaviour
{
    internal Rigidbody rb;
    internal Animator anim;
    internal Quaternion targetRotation;

    public float X, Z;
    internal Vector3 movement;

    public float speed;
    public float Fspeed;
    public GameObject ThirdPersonCam;
    public bool flying;

    public bool Cam›sActive() => ThirdPersonCam.activeSelf;

    public abstract void ›sUpdate();
    public abstract void ›sStart();

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        ›sStart();
    }

    public void Update()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        movement = Camera.main.transform.forward * Z + Camera.main.transform.right * X;
        if (!flying) movement.y = 0;

        ›sUpdate();
    }

    public void FixedUpdate()
    {
        if (movement == Vector3.zero) return;

        targetRotation = Quaternion.LookRotation(movement);

        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

        if (flying)
        {
            rb.velocity = new Vector3(movement.normalized.x * Fspeed, movement.normalized.y * Fspeed, movement.normalized.z * Fspeed);

            rb.MoveRotation(targetRotation);
        }
        if(!flying)
        {
            rb.velocity = new Vector3(movement.normalized.x * speed, rb.velocity.y, movement.normalized.z * speed);

            if (Cam›sActive()) rb.MoveRotation(targetRotation);
        }

        
    }
}
