using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] ButtonCover;
    public int levelit = FQuestionPopupScript.LevelUnlocked;
    void Start()
    {
        for(int i = 1;i < 9;i++)
        {
            buttons[i].interactable = false;
            ButtonCover[i].SetActive(true);
        }
        for (int i = 0; i <= levelit; i++)
        {
            buttons[i].interactable = true;
            ButtonCover[i].SetActive(false);
        }
    }
}
