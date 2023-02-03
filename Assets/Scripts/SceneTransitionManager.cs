using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    [SerializeField] int timeToStartNewScene;

    public void StartGame()
    {
        FindObjectOfType<MusicManager>().FadeOutMusic();
        StartCoroutine(StartNewSceneDelayed());
    }

    IEnumerator StartNewSceneDelayed()
    {
        yield return new WaitForSeconds(timeToStartNewScene);
        SceneManager.LoadScene("RootChaseMainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
