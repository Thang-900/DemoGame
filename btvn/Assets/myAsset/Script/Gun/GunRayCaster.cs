using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRayCaster : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;
    public int damage;
    public void PerformRayCasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position
           , aimingCamera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            ShowHitEffect(hitInfo);
            DeliveryDamage(hitInfo);
        }
    }
    private void ShowHitEffect(RaycastHit hitInfo)
    {
        HitSurface hitSurface = hitInfo.collider.GetComponent<HitSurface>();
        if (hitSurface != null)
        {
            Debug.Log("Hit surface type: " + hitSurface.surfaceType);
            GameObject effectPrefab = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if (effectPrefab != null)
            {
                Quaternion effectRotation=Quaternion.LookRotation(hitInfo.normal);
                Instantiate(effectPrefab, hitInfo.point, effectRotation);
            }
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

