using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Restart()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().ClearList(); //ɾ��gameManager�е�enemyʵ�������ã�������reload�󱨴�
        SceneManager.LoadScene(0);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
