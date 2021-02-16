using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
     public GameObject manual;

     public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameManual()
    {
        if (manual.activeSelf)
                manual.SetActive(false);
            else
                manual.SetActive(true);
    }
      
    public void GameExit()
    {
        Application.Quit();
    }
}
