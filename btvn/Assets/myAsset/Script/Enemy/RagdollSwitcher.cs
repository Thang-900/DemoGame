using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    public Animator anim;
    public Rigidbody[] rigids;
    [ContextMenu("Retrieve rigidbody")]
    private void RetrieveRigitbodies()
    {
        rigids = GetComponentsInChildren<Rigidbody>();
    }
    [ContextMenu("clear Ragdoll")]
    private void ClearRagdoll()
    {
        CharacterJoint[] joints = GetComponentsInChildren<CharacterJoint>();
        for (int i = 0; i < joints.Length; i++)
        {
            DestroyImmediate(joints[i]);
        }
        Rigidbody[] rigidList = GetComponentsInChildren<Rigidbody>();
        foreach (var body in rigidList)
        {
            DestroyImmediate(body);
        }
        Collider[] colls = GetComponentsInChildren<Collider>();
        foreach (var coll in colls)
        {
            DestroyImmediate(coll);
        }

    }
    [ContextMenu("Disable Ragdoll")]
    public void DisableRagDoll()
    {
        SetRagDoll(false);
    }
    [ContextMenu("Enable Ragdoll")]
    public void EnsableRagdoll()
    {
        SetRagDoll(true);
    }
    private void SetRagDoll(bool ragDollEnable)
    {
        anim.enabled = !ragDollEnable;
        foreach (var rigid in rigids)
        {
            rigid.isKinematic = !ragDollEnable;
        }
    }
    [ContextMenu("add HitSurface")]
    private void AddHitSurface()
    {
        Collider[] colliders= GetComponentsInChildren<Collider>();
        foreach(var coll in colliders)
        {
            if(gameObject.GetComponent<HitSurface>()==null)
            {
                var hitSurface=coll.gameObject.AddComponent<HitSurface>();
                hitSurface.surfaceType=HitSurFaceType.Blood;
            }
        }
    }
}
