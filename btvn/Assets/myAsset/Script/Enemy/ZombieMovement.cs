using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class ZombieMovement : MonoBehaviour
{
    public Transform playerFoot;
    public Animator anim;
    public NavMeshAgent agnent;
    public float reachingRadious;
    public UnityEvent onDestinationReached;
    public UnityEvent onStartMoving;

    private bool _isMovingValue;
    public bool IsMoving
    {
        get => _isMovingValue;
        private set
        {
            if ((_isMovingValue == value)) return;
            _isMovingValue = false;
            OnIsMovingValueChange();
        }
    }
    private void OnIsMovingValueChange()
    {
        agnent.isStopped = !_isMovingValue;
        anim.SetBool("IsWalking", _isMovingValue);
        if (_isMovingValue)
        {
            onStartMoving.Invoke();
        }
        else
        {
            onDestinationReached.Invoke();
        }
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerFoot.position);
        IsMoving=distance > reachingRadious;
        if(IsMoving)
        {
            agnent.SetDestination(playerFoot.position);
        }
    }
}
