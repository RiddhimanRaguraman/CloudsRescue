using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoardSelector : MonoBehaviour
{
    public GameObject selectButton;

    private void Start()
    {
        selectButton.SetActive(false); // Hide the "Select" button initially
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            selectButton.SetActive(true); // Show the "Select" button when the player collides with the BlackBoardSelector and question is not answered
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            selectButton.SetActive(false); // Hide the "Select" button when the player exits the BlackBoardSelector
        }
    }
}

