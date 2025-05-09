using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingGameScript : MonoBehaviour
{
    public int nextLevel = 3;
    public Slider progressBar;
    
    private void Start()
    {
        progressBar.maxValue = 100;
        progressBar.minValue = 0;
        progressBar.value = 0;
        
        StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(int level)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);
        if (asyncLoad != null)
        {
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                progressBar.value = asyncLoad.progress;
                if (asyncLoad.progress >= 0.9f)
                {
                    asyncLoad.allowSceneActivation = true;
                }
                
                yield return null;
            }
        }

        else
        {
            Debug.LogError("asyncLoad == null");
        }
    }
}