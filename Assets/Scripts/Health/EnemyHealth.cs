using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] int points = 100;
    [SerializeField] AudioClip deadSFX;

    Manager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        manager.AddEnemy(gameObject); //所有enemy实例注册到gameManager中
    }

    protected override void Die()
    {
        AudioSource.PlayClipAtPoint(deadSFX, transform.position);
        isDead = true;
        gameObject.SetActive(false);
        manager.CheckEnemyAlive(); //每个敌人消失后判断是否过关
    }

    public int getPoints()
    {
        return points;
    }


}
