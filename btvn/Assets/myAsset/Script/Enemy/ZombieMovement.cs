using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieMovement : MonoBehaviour
{
    public Transform playerFoot;
    public Animator anim;
    public NavMeshAgent agnent;
    public float reachingRadious;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerFoot.position);
        if (distance>reachingRadious)
        {
            agnent.isStopped = false;
            agnent.SetDestination(playerFoot.position);
            
        }
        else
        {
            agnent.isStopped = true;

        }
    }
}
