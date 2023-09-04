using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class LevelManager : MonoBehaviour
{
    public Animator transition1;
    public Animator transition2;
    public float transitionTime = 1f;
    public GameObject Panel;
    public int nextSceneLoad;

    public void OpenLevel()
    {
        string levelName = "Level " + (SceneManager.GetActiveScene().buildIndex + 1);
        // SceneManager.LoadScene(levelName);
        if(nextSceneLoad > PlayerPrefs.GetInt("levelit"))
        {
            PlayerPrefs.SetInt("levelit", nextSceneLoad);
        }
        StartCoroutine(LoadLevel(levelName));
        // UnityEngine.Debug.Log(levelName);
    }

    IEnumerator LoadLevel(string levelName)
    {
        transition1.SetTrigger("Start");
        transition2.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        Panel.SetActive(false);
        SceneManager.LoadScene(levelName);
    }
}
