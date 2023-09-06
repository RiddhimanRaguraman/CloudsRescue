using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CharacterInteraction : MonoBehaviour
{
    public GameObject grandsonGameObject; // GameObject for grandson
    public GameObject grandpaGameObject; // GameObject for grandpa
    public TMP_Text textField;
    public Button nextButton;
    public Animator transition;
    private CharacterData[] characters;
    private int currentCharacterIndex = 0;
    private int currentDialogueIndex = 0;
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
        grandsonGameObject.SetActive(false);
        grandpaGameObject.SetActive(false);
        textField.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);

        CharacterData currentCharacter = characters[currentCharacterIndex];

        if (currentCharacter.characterName == "Ethan")
        {
            grandsonGameObject.SetActive(true);
            grandpaGameObject.SetActive(false);
        }
        else if (currentCharacter.characterName == "Harrison")
        {
            grandpaGameObject.SetActive(true);
            grandsonGameObject.SetActive(false);
        }

        if (currentDialogueIndex < currentCharacter.dialogues.Length)
        {
            typingCoroutine = StartCoroutine(TypeText(currentCharacter.dialogues[currentDialogueIndex]));
        }
        else
        {
            currentDialogueIndex = 0;
            currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;

            if (currentCharacterIndex == 0)
            {
                StartCoroutine(LoadLevelStartPage());
            }
            else
            {
                StartDialogue();
            }
        }
    }

    private IEnumerator TypeText(string dialogue)
    {
        textField.text = "";

        foreach (char letter in dialogue)
        {
            textField.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        nextButton.gameObject.SetActive(true);
    }

    public void ContinueToNextDialogue()
    {
        grandsonGameObject.SetActive(false);
        grandpaGameObject.SetActive(false);
        textField.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        currentDialogueIndex++;

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        StartDialogue();
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
