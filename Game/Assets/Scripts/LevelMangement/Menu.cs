using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class Menu : MonoBehaviour
{
    public Animator transition1;
    public Animator transition2;
    public float transitionTime = 1f;
    public GameObject Panel;

    public void OpenLevel(int levelId)
    {
        string levelName = "Level Selector " + levelId ;
        StartCoroutine(LoadLevel(levelName));
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
