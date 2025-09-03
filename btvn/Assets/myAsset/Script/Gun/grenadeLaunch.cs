using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeLaunch : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    public GameObject bulletPrefab;
    public Transform firingPos;
    public float bulletSpeed;
    public AudioSource shootingSound;
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            AddProjecttile();
        }
    }
    //void ShootBullet()
    //{
    //    anim.SetTrigger("shoot");

    //}
    public void playFireSound() => shootingSound.Play();
    public void AddProjecttile()
    {
        GameObject bullet = Instantiate(bulletPrefab, firingPos.position, firingPos.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firingPos.forward * bulletSpeed;
    }
}
