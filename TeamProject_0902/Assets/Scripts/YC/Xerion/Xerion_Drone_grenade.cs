using UnityEngine;

public class Xerion_Drone_grenade : MonoBehaviour
{
    public ParticleSystem FXToDeatch;
    [HideInInspector]
    public float Speed = 15f;
    [HideInInspector]
    public GameObject ImpactFX;
    [HideInInspector]
    public float ImpactFXDestroyDelay = 2f;
    [HideInInspector]
    public float ImpactOffset = 0.15f;

    private Rigidbody grenade;
    private Vector3 grenadeDir;
    public float gravity = -10;
    public float height = 10;


    private void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    float CalculateY(Vector3 Launch, Vector3 Dest)
    {
        float displacementY = Dest.y - Launch.y;


        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * height);
   

        return  velocityY.y * -Mathf.Sign(gravity);
    }

    public void Setup(Vector3 ShootDir, Vector3 Dest)
    {

        // grenade.velocity = CalculateLaunchVelocity(Dest);

        grenadeDir = new Vector3(ShootDir.x, CalculateY(ShootDir, Dest) , ShootDir.z);
    }

    public void Setup(Vector3 ShootDir)
    {
        grenadeDir = ShootDir;
    }



    private void FixedUpdate()
    {
        if (Speed == 0)
            return;
        transform.position += grenadeDir * (Speed * Time.deltaTime);
        //transform.localPosition += new Vector3(Direct.x * (Speed * Time.deltaTime),
        //    Direct.y, Direct.z * (Speed * Time.deltaTime));
    }

    void OnCollisionEnter(Collision collision)
    {
        //ignore collisions with projectile
        var contact = collision.contacts[0];
        if (contact.otherCollider.name.Contains("Projectile"))
            return;

        Speed = 0;

        var hitPosition = contact.point + contact.normal * ImpactOffset;

        if (ImpactFX != null)
        {
            var impact = Instantiate(ImpactFX, hitPosition, Quaternion.identity);
            impact.transform.localScale = transform.localScale;
            Destroy(impact, ImpactFXDestroyDelay);
        }

        FXToDeatch.transform.parent = null;
        FXToDeatch.Stop(true);
        Destroy(FXToDeatch.gameObject, ImpactFXDestroyDelay);

        Destroy(gameObject);
    }
}
