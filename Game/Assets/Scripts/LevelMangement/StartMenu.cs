using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Animator transition;
    public Animator dc1;
    public Animator dc2;

    //public AudioSource audio1;

    public float transitionTime = 1f;

    public void PlayButton()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void HomeButton()
    {
        StartCoroutine(LoadLevelHome());
    }
    /*pulbic void ButtonClick()
    {
        audio2.Play();
    }*/
    public void OpenLevel(int levelId)
    {
        Debug.Log("Level " + levelId);
        string levelName = "Level " + levelId;
        StartCoroutine(LoadLevelLift(levelName));
    }
    IEnumerator LoadLevel(int i)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + i);
    }
    IEnumerator LoadLevelHome()
    {
        dc1.SetTrigger("Close");
        dc2.SetTrigger("Close");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadSceneAsync(0);
    }
    IEnumerator LoadLevelLift(string levelName)
    {
        dc1.SetTrigger("Close");
        dc2.SetTrigger("Close");

        yield return new WaitForSeconds(3f);

        SceneManager.LoadSceneAsync(levelName);
    }

}
