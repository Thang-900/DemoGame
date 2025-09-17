using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRayCaster : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;
    public int damage;
    public void PerformRayCasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position
           , aimingCamera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMarkerPrefab, hitInfo.point,
                effectRotation);
            DeliveryDamage(hitInfo);
        }
    }
    private void DeliveryDamage(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.GetComponentInParent<Health>();
        if (health != null)
        {
            health.takeDamage(damage);
        }
    }
}

