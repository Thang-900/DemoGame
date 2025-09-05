using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutoShooting : MonoBehaviour
{
    public Animator anim;
    public int rpm;
    public AudioSource shootSound;
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;
    public UnityEvent onShoot;
    public float distance;
    private float lastShoot;
    private float interval;

    private void Start()
    {
        interval = 60f / rpm;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }
    private void UpdateFiring()
    {
        if (Time.time - lastShoot >= interval)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }
    private void Shoot()
    {
        shootSound.Play();
        PerformRayCasting();
        onShoot.Invoke();
    }
    private void PerformRayCasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position
            , aimingCamera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMarkerPrefab, hitInfo.point,
                effectRotation);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(aimingCamera.transform.position, aimingCamera.transform.position + aimingCamera.transform.forward * distance);
    }
}
