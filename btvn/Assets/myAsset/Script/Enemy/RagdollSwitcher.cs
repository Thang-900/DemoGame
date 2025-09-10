using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
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
        for (int i=0;i<joints.Length;i++)
        {
            DestroyImmediate(joints[i]);
        }
        Rigidbody[] rigidList = GetComponentsInChildren<Rigidbody>();
        foreach(var body in rigidList)
        {
            DestroyImmediate(body);
        }
        Collider[] colls = GetComponentsInChildren<Collider>();
        foreach (var coll in colls)
        {
            DestroyImmediate(coll);
        }
        
    }
    [ContextMenu("Enable Ragdoll")]
    [ContextMenu("Disable Ragdoll")]
    public void DisableRagDoll()
    {
        SetRagdoll(true);
    }
    public void SetRagdoll(bool ragdollEnable)
    {
        foreach(var rigid in rigids)
        {
            rigid.isKinematic = !ragdollEnable;
        }
    }

}
