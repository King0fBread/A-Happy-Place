using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    //Empty class to execute the coroutine from
    private class LoadingSceneAsyncMonoBehaviour : MonoBehaviour { }
    private static Action _onLoaderCallback;
    private static AsyncOperation _sceneLoadingProgess;
    public enum Scenes
    {
        MenuScene,
        LoadingScene,
        GameScene,
    }
    public static void LoadScene(Scenes sceneToLoad)
    {
        //Switches to the Loading Scene
        SceneManager.LoadScene(Scenes.LoadingScene.ToString());

        //Subscribes the actual scene loading to the action, through a 'dummy' gameobject
        _onLoaderCallback = () =>
        {
            GameObject loadingSceneObject = new GameObject("LoadingSceneAsyncObj");
            loadingSceneObject.AddComponent<LoadingSceneAsyncMonoBehaviour>().StartCoroutine(LoadSceneAsync(sceneToLoad));
        };
    }
    public static void LoaderCallback()
    {
        if(_onLoaderCallback != null)
        {
            _onLoaderCallback();
            _onLoaderCallback = null;
        }
    }
    private static IEnumerator LoadSceneAsync(Scenes sceneToLoad)
    {
        //Skips the first frame and starts the actual loading process
        yield return null;
        _sceneLoadingProgess = SceneManager.LoadSceneAsync(sceneToLoad.ToString());
        //Checks if the loading is done, if not - skips to next frame
        while (!_sceneLoadingProgess.isDone)
        {
            yield return null;
        }
    }
    public static float GetCurrentSceneLoadingProgress()
    {
        if (_sceneLoadingProgess != null)
        {
            return _sceneLoadingProgess.progress;
        }
        else return 1f;
    }
}
