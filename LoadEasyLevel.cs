using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEasyLevel : MonoBehaviour
{

    public void LoadMyScene()
    {
        StartCoroutine(LoadYourAsyncScene());
    }


    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the scene whilst in the background as the Main Scene.
        // meaning you can use this for loading screens.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Easy");

        // Will wait until an asynchronous scene is done loading
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
