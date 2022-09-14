using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] int lifes = 2;
    [SerializeField] Transform respwanPoint;
    [SerializeField] float respwanTime = 1f;
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] AudioClip deadSFX;

    private IEnumerator Respawn() //重生：改变player颜色，限制player控制,设置生命值，最后移动到指定位置
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        AudioSource.PlayClipAtPoint(deadSFX, transform.position);
        isDead = true;
        Color preColor = gameObject.GetComponent<MeshRenderer>().material.color;
        gameObject.GetComponent<MeshRenderer>().material.color  = Color.gray;
        yield return new WaitForSeconds(respwanTime);

        gameObject.GetComponent<MeshRenderer>().material.color = preColor;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        gameObject.transform.position = respwanPoint.position;
        healthPoint = 2;
        lifes--;
        isDead = false;

    }

    private void GameOver()
    {
        isDead = true;
        AudioSource.PlayClipAtPoint(gameOverSFX, transform.position);
        GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuControl>().Open();
        gameObject.SetActive(false);
    }

    protected override void Die()
    {
        if (lifes > 0)
        {
            StartCoroutine(Respawn());

        }
        else
        {
            GameOver();
        }
    }

    public int GetLifes()
    {
        return lifes;
    }
    public void SetLifes(int n)
    {
        lifes = n;
    }

}
