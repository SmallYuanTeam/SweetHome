using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine.UI;

public class SceneManagerHelper : MonoBehaviour
{
    private HashSet<string> loadedScenes = new HashSet<string>();
    public string mainSceneName = "MainScene"; // 主场景的名称
    private ProCamera2DTransitionsFX transitionsFX;

    void Awake()
    {
        transitionsFX = ProCamera2DTransitionsFX.Instance; 
    }

    public void LoadSceneWithTransition(List<string> scenesToLoad)
    {
        StartCoroutine(LoadScenesWithTransitionCoroutine(scenesToLoad));
    }

    private IEnumerator LoadScenesWithTransitionCoroutine(List<string> scenesToLoad)
    {
        transitionsFX.TransitionExit();
        yield return new WaitForSeconds(transitionsFX.DurationExit);

        List<string> scenesToUnload = new List<string>(loadedScenes);
        foreach (var sceneName in scenesToUnload)
        {
            if (!scenesToLoad.Contains(sceneName) && sceneName != mainSceneName)
            {
                yield return SceneManager.UnloadSceneAsync(sceneName);
                loadedScenes.Remove(sceneName); 
            }
        }

        yield return null;

        foreach (var sceneName in scenesToLoad)
        {
            if (!loadedScenes.Contains(sceneName))
            {
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                yield return asyncLoad; 

                loadedScenes.Add(sceneName);
            }
        }
        transitionsFX.TransitionEnter();
    }


    public void UnloadAllScenesExcept(string sceneToKeep)
    {
        StartCoroutine(UnloadScenesExceptCoroutine(sceneToKeep));
    }

    private IEnumerator UnloadScenesExceptCoroutine(string sceneToKeep)
    {
        foreach (var sceneName in loadedScenes)
        {
            if (sceneName != sceneToKeep && sceneName != mainSceneName)
            {
                yield return SceneManager.UnloadSceneAsync(sceneName);
            }
        }

        loadedScenes.Clear();
        loadedScenes.Add(sceneToKeep);
        if (!string.IsNullOrEmpty(mainSceneName) && sceneToKeep != mainSceneName)
        {
            loadedScenes.Add(mainSceneName);
        }
    }
    
}
