using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Restart()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().ClearList(); //删除gameManager中的enemy实例的引用，否则在reload后报错
        SceneManager.LoadScene(0);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
