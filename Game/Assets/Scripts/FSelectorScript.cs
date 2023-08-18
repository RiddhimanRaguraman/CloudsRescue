using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSelectorScript : MonoBehaviour
{
    public GameObject selectButton;
    private bool isPlayerColliding = false;
    private bool isQuestionAnswered = false;
    public GameObject FinalQ;

    private void Start()
    {
        selectButton.SetActive(false); // Hide the "Select" button initially
        FinalQ.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.GetPlayerScore() == 3)
        {
            FinalQ.SetActive(true);
        }
        if (isPlayerColliding && GameManager.instance.GetPlayerScore() == 3)
        {
            selectButton.SetActive(true); // Show the "Select" button when the player is colliding with the FinalQ and the player score is 3
        }
        else
        {
            selectButton.SetActive(false); // Hide the "Select" button when the player is not colliding with the FinalQ or player score is not 3
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerColliding = true; // Set the flag when the player collides with the FinalQ trigger
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerColliding = false; // Reset the flag when the player exits the FinalQ trigger
        }
    }
    
    public void MarkQuestionAnswered()
    {
        isQuestionAnswered = true; // Mark the question as answered for this QSelector
    }

    public void HideSelectButton()
    {
        selectButton.SetActive(false); // Hide the "Select" button for this QSelector
    }
}
