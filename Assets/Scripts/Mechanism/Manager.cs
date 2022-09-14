using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] AudioClip successSFX;
    [SerializeField] Transform cloud;
    [SerializeField] GameObject lightingBallPrefab;

    private static Manager instance;
    List<GameObject> enemyList;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject); //确保单例
        }
        enemyList = new List<GameObject>();
    }

    private void Start()
    {
        StartCoroutine(SpwanLighting());
    }

    private IEnumerator LoadNextScene()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        int points = player.GetComponent<CollisionHandler>().GetPoints();
        int lifes = player.GetComponent<PlayerHealth>().GetLifes();

        yield return new WaitForSeconds(2f);
        int n = SceneManager.GetActiveScene().buildIndex + 1;
        if (n >= SceneManager.sceneCountInBuildSettings) n = 0;
        yield return  SceneManager.LoadSceneAsync(n);

        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CollisionHandler>().SetPoints(points);
        player.GetComponent<PlayerHealth>().SetLifes(lifes);                //gameManager跨场景将生命数与分数传递给player;
    }

    private IEnumerator SpwanLighting()
    {
        if(cloud != null)
        {
            int num = 0;

            while (num < 3)
            {
                yield return new WaitForSeconds(6f);
                Instantiate(lightingBallPrefab, cloud.position, Quaternion.identity);
                num++;

            }
        }

           
    }

    public void AddEnemy(GameObject enemy)
    {
        if (enemy.tag == "Enemy")
        {
            enemyList.Add(enemy);
        }
    }

    public void CheckEnemyAlive()
    {

        foreach (GameObject enemy in enemyList)
        {
            if (enemy.activeInHierarchy == true) return;
        }
        AudioSource.PlayClipAtPoint(successSFX, transform.position); //在enemy调用后无法再找到enemy，即enemy全部消灭，关卡完成
        StartCoroutine(LoadNextScene());
    }

    public void ClearList()
    {
        enemyList.Clear();
    }

}
