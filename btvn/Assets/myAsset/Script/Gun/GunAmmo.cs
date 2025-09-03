using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public grenadeLaunch gun;
    public Animator anim; // không có
    public AudioSource[] reloadSounds;  // không có
    public UnityEvent loadedAmmoChanged;

    private int _loadedAmmo;
    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            LoadedAmmo = value;
            loadedAmmoChanged.Invoke();
            if (_loadedAmmo <= 0)
            {
                lockShooting();
            }
        }
    }
    private void Start()
    {
        unlockShooting();
    }
    public void singleFireAmmoCounter() => LoadedAmmo--;
    public void lockShooting() => gun.enabled = false;
    private void unlockShooting()
    {
        gun.enabled = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    private void Reload()
    {
        lockShooting();
    }
    public void AddAmmo() => refillAmmo();
    private void refillAmmo()
    {
        LoadedAmmo = magSize;
    }
}
