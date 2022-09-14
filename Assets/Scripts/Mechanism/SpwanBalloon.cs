using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanBalloon : MonoBehaviour
{

    [SerializeField] Transform[] spwanLocation;
    [SerializeField] GameObject balloonPrefab;
    [SerializeField] [Range(0, 50)] int poolSize = 8;
    [SerializeField] [Range(1f, 10f)] float time = 3f;
   // [SerializeField] Transform parent;

    int t = 0; //气球计数
    List<GameObject> pool;

    private void Awake()
    {
        populatePool();
    }
    private void Start()
    {
        StartCoroutine(GenarateObject());
    }

    private void populatePool()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(balloonPrefab, spwanLocation[0].position, Quaternion.Euler(0, 0, 90));
            obj.transform.parent = transform;
            pool.Add(obj); 
            obj.SetActive(false);
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].transform.position = spwanLocation[Random.Range(0, spwanLocation.Length)].position; //随机在一个生成点出现气球
                pool[i].SetActive(true);
                return;
            }

        }
        GameObject obj = Instantiate(balloonPrefab, spwanLocation[Random.Range(0, spwanLocation.Length)].position, Quaternion.Euler(0, 0, 90)); //池中对象不足时触发
        obj.transform.parent = transform;
        pool.Add(obj);
        //Debug.Log("add new one to pool");
        
    }

    private IEnumerator GenarateObject()
    {
        yield return new WaitForSeconds(3f);

        while (t < 20)
        {
            t++;
            EnableObjectInPool();
            yield return new WaitForSeconds(time);
        }
        yield return new WaitForSeconds(10f);
        GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuControl>().TBC();    //

    }


}
