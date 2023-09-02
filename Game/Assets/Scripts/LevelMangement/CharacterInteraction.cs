// using System.Collections;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using DG.Tweening;

// public class CharacterInteraction : MonoBehaviour
// {
//     public TMP_Text textField;
//     public Button nextButton;

//     private string[] dialogues; // An array of dialogues for the interaction
//     private int currentDialogueIndex = 0; // Index of the current dialogue

//     private bool textAnimationCompleted = false;

//     private void Start()
//     {
//         dialogues = new string[]
//         {
//             "Hello, adventurer!",
//             "Welcome to the mystical world.",
//             "Are you ready for an epic journey?"
//             // Add more dialogues as needed
//         };

//         // Start the first dialogue
//         StartDialogue();
//     }

//     private void Update()
//     {
//         // Check for touch input to skip text animation
//         if (Input.touchCount > 0 && textAnimationCompleted)
//         {
//             Touch touch = Input.GetTouch(0);
//             if (touch.phase == TouchPhase.Began)
//             {
//                 ContinueToNextDialogue();
//             }
//         }
//     }

//     public void StartDialogue()
//     {
//         // Show the text panel and start animating the text
//         textField.gameObject.SetActive(true);
//         textField.text = ""; // Clear the text initially
//         textField.DOText(dialogues[currentDialogueIndex], dialogues[currentDialogueIndex].Length * 0.05f)
//             .SetEase(Ease.Linear)
//             .SetUpdate(true)
//             .OnComplete(() =>
//             {
//                 // Text animation complete, set the flag
//                 textAnimationCompleted = true;

//                 // Show the "Next" button
//                 nextButton.gameObject.SetActive(true);
//             });
//     }

//     public void ContinueToNextDialogue()
//     {
//         // Hide the text panel and move to the next dialogue
//         textField.gameObject.SetActive(false);
//         nextButton.gameObject.SetActive(false);

//         // Move to the next dialogue
//         currentDialogueIndex++;

//         // Reset the text animation flag
//         textAnimationCompleted = false;

//         // Check if there are more dialogues
//         if (currentDialogueIndex < dialogues.Length)
//         {
//             StartDialogue();
//         }
//         else
//         {
//             // All dialogues are done, end the interaction or proceed to the next game phase
//             // For example, you can load the next scene or start the gameplay.
//         }
//     }
// }


using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CharacterInteraction : MonoBehaviour
{
    public SpriteRenderer grandsonSpriteRenderer;
    public SpriteRenderer grandpaSpriteRenderer;
    public TMP_Text textField;
    public Button nextButton;
    public Animator transition;
    private CharacterData[] characters; // An array of characters for the interaction
    private int currentCharacterIndex = 0; // Index of the current character
    private int currentDialogueIndex = 0; // Index of the current dialogue
    private Coroutine typingCoroutine;

    private void Start()
    {
        characters = new CharacterData[]
        {
            new CharacterData("Ethan", "Sprites/EthanSprite", new string[]
            {
                "Hi, Grandpa! Have you seen Cloud anywhere?",
                "I really miss my dog...",
                "Please, Grandpa, can you give Cloud back?",
            }),
            new CharacterData("Harrison", "Sprites/HarrisonSprite", new string[]
            {
                "Ah, Cloud is with me. You need to focus on your studies.",
                "Life is full of lessons, my dear grandson.",
                "Complete the challenges I've set for you, and Cloud will be yours again.",
            }),
            // Add more characters as needed
        };

        // Start the first dialogue
        StartDialogue();
    }

    public void StartDialogue()
    {
        // Show the text panel and start animating the text
        grandsonSpriteRenderer.gameObject.SetActive(false);
        grandpaSpriteRenderer.gameObject.SetActive(false);
        textField.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);

        // Get the current character
        CharacterData currentCharacter = characters[currentCharacterIndex];

        // Set the character's sprite
        if (currentCharacter.characterName == "Ethan")
        {
            grandsonSpriteRenderer.gameObject.SetActive(true);
            grandpaSpriteRenderer.gameObject.SetActive(false);
            grandsonSpriteRenderer.sprite = Resources.Load<Sprite>(currentCharacter.imagePath);
        }
        else if (currentCharacter.characterName == "Harrison")
        {
            grandpaSpriteRenderer.gameObject.SetActive(true);
            grandsonSpriteRenderer.gameObject.SetActive(false);
            grandpaSpriteRenderer.sprite = Resources.Load<Sprite>(currentCharacter.imagePath);
        }

        // Cancel any ongoing typing coroutine
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // Start a new typing coroutine
        typingCoroutine = StartCoroutine(TypeText(currentCharacter.dialogues[currentDialogueIndex]));
    }

    private IEnumerator TypeText(string dialogue)
    {
        textField.text = ""; // Clear the text

        foreach (char letter in dialogue)
        {
            textField.text += letter;
            yield return new WaitForSeconds(0.05f); // Delay between each letter
        }

        // Text animation complete, show the "Next" button
        nextButton.gameObject.SetActive(true);
    }

    public void ContinueToNextDialogue()
    {
        // Hide the text panel and move to the next dialogue
        grandsonSpriteRenderer.gameObject.SetActive(false);
        grandpaSpriteRenderer.gameObject.SetActive(false);
        textField.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        // Move to the next dialogue
        currentDialogueIndex++;

        // Check if the current character's dialogues are done
        CharacterData currentCharacter = characters[currentCharacterIndex];
        if (currentDialogueIndex < currentCharacter.dialogues.Length)
        {
            StartDialogue();
        }
        else
        {
            // Move to the next character's dialogues
            currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;
            currentDialogueIndex = 0;

            if (currentCharacterIndex == 0)
            {
                // All dialogues are done, go to the "StartPage" scene
                StartCoroutine(LoadLevelStartPage());
            }
            else
            {
                StartDialogue();
            }
        }
    }
    IEnumerator LoadLevelStartPage()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadSceneAsync("StartPage");
    }
}

[System.Serializable]
public class CharacterData
{
    public string characterName;
    public string imagePath;
    public string[] dialogues;

    public CharacterData(string name, string path, string[] lines)
    {
        characterName = name;
        imagePath = path;
        dialogues = lines;
    }
}
