using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QSelectorScript : MonoBehaviour
{
    public GameObject selectButton;
    // private bool isPlayerColliding = false;
    private bool isQuestionAnswered = false;


    private void Start()
    {
        selectButton.SetActive(false); // Hide the "Select" button initially
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !GameManager.instance.IsQuestionAnsweredForSelector(gameObject))
        {
            selectButton.SetActive(true); // Show the "Select" button when the player collides with the QSelector and question is not answered
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            selectButton.SetActive(false); // Hide the "Select" button when the player exits the QSelector
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
