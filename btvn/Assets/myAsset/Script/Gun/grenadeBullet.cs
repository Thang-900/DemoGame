using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explosionEffect;
    public float explosionRadius = 5f;
    public float explosionForce;
    public int damage;

    private List<Health> oldVictims = new List<Health>();
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObject();
    }
    private void BlowObject()
    {
        oldVictims.Clear();
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider obj in affectedObjects)
        {
            DeliveryDamage(obj);
            if (obj.GetComponent<Rigidbody>() != null)
            {
                obj.GetComponent<Rigidbody>().AddExplosionForce(explosionForce,
                    transform.position, explosionRadius, 1,
                    ForceMode.Impulse);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    private void DeliveryDamage(Collider victim)
    {

        Health health = victim.GetComponentInParent<Health>();
        if (health != null && !oldVictims.Contains(health))
        {
            health.takeDamage(damage);
            oldVictims.Add(health);
        }
    }
}

