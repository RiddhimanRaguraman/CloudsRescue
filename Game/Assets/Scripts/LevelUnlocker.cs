using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] ButtonCover;
    void Start()
    {
        int levelit = PlayerPrefs.GetInt("levelit", 4);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 4 > levelit)
            {
                buttons[i].interactable = false;
                ButtonCover[i].SetActive(true);
            }
        }
    }
    public void ResetPrefs()
    {
        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            ButtonCover[i].SetActive(true);
        }
        PlayerPrefs.DeleteAll();
    }
}
