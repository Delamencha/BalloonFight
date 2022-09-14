using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{

    [SerializeField] protected int healthPoint = 2;
   
    protected bool isDead = false;
    protected abstract void Die();

    public void DecreaseHealth(int damage)
    {
        if (isDead) return;
        healthPoint -= damage;
        if(healthPoint <= 0)
        {
            Die();

        }

    }

    public bool IsDead()
    {
        return isDead;
    }
    
}
