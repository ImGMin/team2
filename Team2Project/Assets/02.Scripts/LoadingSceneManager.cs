using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadingSceneManager : MonoBehaviour
{
    public Slider slider;
    public string SceneName;

    private float time;

    void Start() {
        StartCoroutine(LoadAsynSceneCoroutine());   
    }

    IEnumerator LoadAsynSceneCoroutine() {

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        operation.allowSceneActivation = false;

        

        while (!operation.isDone) {

            time =+ Time.time;

            slider.value = time / 10f;

            if(time > 10) {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }
}