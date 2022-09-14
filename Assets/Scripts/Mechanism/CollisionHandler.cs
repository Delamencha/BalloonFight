using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField] float attackBounce = 6f;
    [SerializeField] float damageBounce = 4f;
    [SerializeField] AudioClip attackSFX;
    [SerializeField] AudioClip damageSFX;

    PlayerMovement pm;
    PlayerHealth ph;
    int myPoints = 0;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        ph = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy") return;

        //判断碰撞发生位置（player在头部/气球被攻击时扣血）

        ContactPoint cp = collision.GetContact(0);
        Vector3 tartgetToPlayer = transform.position - cp.point;
        EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
        if(cp.point.y < transform.position.y - 0.2)  //判定碰撞点在player脚部
        {
            ProcessAttack(enemyHealth);
            pm.ProcessBounce(tartgetToPlayer, attackBounce);
        }
        else if (cp.point.y > transform.position.y + 0.2) //判定碰撞点在player头部
        {
            ProcessDamage();
            pm.ProcessBounce(tartgetToPlayer, damageBounce);
        }

        
        
    }


    private void ProcessAttack(EnemyHealth enemyHealth)
    {
        if(enemyHealth != null)
        {
            GainPoints(enemyHealth.getPoints());
            enemyHealth.DecreaseHealth(1);     
            AudioSource.PlayClipAtPoint(attackSFX, transform.position);
        }
        
    }

    private void ProcessDamage()
    {
        ph.DecreaseHealth(1);
        AudioSource.PlayClipAtPoint(damageSFX, transform.position);
        
    }

    public void GainPoints(int points)
    {
        myPoints += points;
    }

    public void SetPoints(int n)
    {
        myPoints = n;
    }

    public int GetPoints()
    {
        return myPoints;
    }


}
