using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private class LoadingMonoBehaviour : MonoBehaviour { }

    public enum Scene
    {
        TitleScreen,
        InitialCutsceneScreen,
        SampleScene,
        LoadingScreen,
        FinalCutsceneScreen
    }

    private static Action onLoaderCallback;
    private static AsyncOperation loadAsyncOperation;

    public static void Load(Scene scene)
    {
        onLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsyc(scene));
        };

        SceneManager.LoadScene(Scene.LoadingScreen.ToString());
    }

    public static IEnumerator LoadSceneAsyc(Scene scene)
    {
        yield return null;

        loadAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while (!loadAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if (loadAsyncOperation != null)
        {
           return loadAsyncOperation.progress;
        }
        return 1f;
    }

    public static void LoaderCallback()
    {
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
