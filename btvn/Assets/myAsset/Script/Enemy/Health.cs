using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public Animator anim;
    private int healthPoint;
    public UnityEvent onDie; 
    private bool isdead => healthPoint <= 0;
    private void Start()
    {
        healthPoint = maxHealthPoint;
    }
    public void takeDamage(int damage)
    {
        if (isdead) return;
        healthPoint -= damage;
        if (isdead)
        {
            Destroy(gameObject);
        }
    }
    private void Die()
    {
        anim.SetTrigger("Die");
        onDie.Invoke();
    }
}
