using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBuilding : MonoBehaviour
{
    [SerializeField]
    int bno;

    public Animator transition;

    public float transitionTime = 1f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        string BuildingName = "Level Selector " + bno;
        StartCoroutine(LoadLevel(BuildingName));
    }

    IEnumerator LoadLevel(string BuildingName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadSceneAsync(BuildingName);
    }
}
