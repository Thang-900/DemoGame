using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeBullet : MonoBehaviour
{
    public GameObject explosionEffect;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

