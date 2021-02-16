using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    bool pause = false;
    
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            {
                pause=!pause;
            }

            if(pause)
            {
                menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true; 
                Time.timeScale = 0;
            }

            if(!pause)
            {
                menu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
    }
    
    public void ToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
