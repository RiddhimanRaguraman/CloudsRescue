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
        int levelit = PlayerPrefs.GetInt("levelit", 3);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 3 > levelit)
            {
                buttons[i].interactable = false;
                ButtonCover[i].SetActive(true);
            }
        }
    }
}
