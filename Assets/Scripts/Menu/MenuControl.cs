using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    [SerializeField] GameObject text;

    private void Start()
    {
        Close();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.enabled == false)
            {
                Open();
            }
            else
            {
                Close();
            }

        }
    }

    public void Open()
    {
        pauseMenu.enabled = true;
        Time.timeScale = 0;
        //Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Close()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void TBC()
    {
        if(text != null)
        {
            text.SetActive(true);
        }
        
    }
}
