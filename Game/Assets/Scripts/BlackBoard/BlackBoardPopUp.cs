using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoardPopUp : MonoBehaviour
{
    public GameObject secondGameObjectPopup; // Reference to the UI pop-up GameObject for the second GameObject
    public GameObject button;
    public GameObject joyStick;
    
    private void Start()
    {
        secondGameObjectPopup.SetActive(false); // Hide the second game object pop-up initially
    }

    public void ShowPopup()
    {
        secondGameObjectPopup.SetActive(true); // Show the pop-up for the second GameObject
        button.SetActive(false);
        joyStick.SetActive(false);
    }

    public void ReturnToGame()
    {
        secondGameObjectPopup.SetActive(false); // Hide the pop-up for the second GameObject
        // Implement any other functionality to return to the game here
        button.SetActive(true);
        joyStick.SetActive(true);
    }
}
