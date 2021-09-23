using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xerion_Drone_Grenade : MonoBehaviour
{
    public ParticleSystem FXToDeatch;
    [HideInInspector]
    public float Speed = 1.5f;
    [HideInInspector]
    public GameObject ImpactFX;
    [HideInInspector]
    public float ImpactFXDestroyDelay = 2f;
    [HideInInspector]
    public float ImpactOffset = 0.15f;
   

    private Vector3 grenadeDir;
    private float time=0.5f;
    private Rigidbody myRigidbody;
    Vector3 target;
    Vector3 origin;

    private void Start()
    {

        Destroy(gameObject, 3.0f);
        myRigidbody = GetComponent<Rigidbody>();
    }
    public void Setup(Vector3 ShootDir, Vector3 Dest)
    {
        origin = ShootDir;
        target = Dest;
    }

    public void SetupVelocity(Vector3 ShootDir, Vector3 Dest)
    {
        //Define the distance
        Vector3 distance = Dest - ShootDir;
        Vector3 distanceXZ = distance;
 

        //create float distance
        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;
        float Vxz = Sxz / time;
        float Vy0 = Sy / time + 0.5f *Mathf.Abs(Physics.gravity.y) * time;

        float Vy = origin.y + Vy0 * time + 0.5f * Physics.gravity.y * time * time;

        Debug.Log("Sy/time " +  Sy / time);
        grenadeDir = distanceXZ.normalized;
        grenadeDir *= Vxz;
        grenadeDir.y = Vy;
    }


    private void FixedUpdate()
    {
        if (Speed == 0)
            return;

        SetupVelocity(transform.position, target);

       
        transform.rotation = Quaternion.LookRotation(grenadeDir);
        myRigidbody.velocity = grenadeDir;
        Debug.Log("Direction" + grenadeDir);
       
    }

    private void SetDirection()
    {

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