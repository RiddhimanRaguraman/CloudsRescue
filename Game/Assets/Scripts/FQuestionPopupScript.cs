using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FQuestionPopupScript : MonoBehaviour
{
    public GameObject questionPopup;
    public TMP_Text questionText; // Use TMP_Text for TextMeshPro
    public TMP_InputField answerInput; // Use TMP_InputField for TextMeshPro
    public GameObject wrongAnswerPanel;
    public TMP_Text scoreText; // Use TMP_Text for TextMeshPro
    public PlayerScore playerScore;
    public GameObject submitButton; // Use UnityEngine.UI.Button for regular UI button
    public GameObject returnButton;
    public float correctAnswer; // Correct answer to the question
    public GameObject button;
    public GameObject joyStick;
    public GameObject EndCanvas;
    public static int LevelUnlocked;
    // public GameObject StartCanvas;
   
    
    private void Start()
    {
        wrongAnswerPanel.SetActive(false); // Hide the second game object pop-up initially
        EndCanvas.SetActive(false);

    }

    public void ShowQuestionPopup()
    {
        joyStick.SetActive(false);
        questionPopup.SetActive(true); // Show the UI panel with the question when the "Select" button is clicked
        button.SetActive(false);
    }

    public void CheckAnswer()
    {
        float userAnswer;
        if (float.TryParse(answerInput.text, out userAnswer))
        {
            if (Mathf.Abs(userAnswer - correctAnswer) < 0.01f)
            {
                // playerScore.IncrementScore(); // Increase the score if the answer is correct
                // scoreText.text = "Score: " + playerScore.GetScore().ToString();
                wrongAnswerPanel.SetActive(false); // Hide the wrong answer panel
                GameManager.instance.MarkQuestionAnsweredForSelector(gameObject);
                GetComponent<FSelectorScript>().HideSelectButton();
                questionPopup.SetActive(false);
                // StartCanvas.SetActive(false);
                LevelUnlocked = SceneManager.GetActiveScene().buildIndex - 3;
                EndCanvas.SetActive(true);
            }
            else
            {
                // submitButton.SetActive(false);
                wrongAnswerPanel.SetActive(true); // Show the wrong answer panel
                //returnButton.SetActive(true);
            }
        }
    }

    public void ClosePopUp()
    {
        questionPopup.SetActive(false);
        submitButton.SetActive(true);
        wrongAnswerPanel.SetActive(false);
        button.SetActive(true);
        joyStick.SetActive(true);
        //returnButton.SetActive(false);
    }
}
