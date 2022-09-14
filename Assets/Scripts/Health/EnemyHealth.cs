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
        manager.AddEnemy(gameObject); //����enemyʵ��ע�ᵽgameManager��
    }

    protected override void Die()
    {
        AudioSource.PlayClipAtPoint(deadSFX, transform.position);
        isDead = true;
        gameObject.SetActive(false);
        manager.CheckEnemyAlive(); //ÿ��������ʧ���ж��Ƿ����
    }

    public int getPoints()
    {
        return points;
    }


}
