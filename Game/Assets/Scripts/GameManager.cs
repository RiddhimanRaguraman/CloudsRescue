using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Dictionary<GameObject, bool> questionAnswerStatus = new Dictionary<GameObject, bool>();
    // private PlayerScore playerScore;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        // playerScore = GetComponent<PlayerScore>();
    }

    public bool IsQuestionAnsweredForSelector(GameObject selector)
    {
        if (questionAnswerStatus.TryGetValue(selector, out bool isAnswered))
        {
            return isAnswered;
        }

        return false;
    }

    public void MarkQuestionAnsweredForSelector(GameObject selector)
    {
        if (questionAnswerStatus.ContainsKey(selector))
        {
            questionAnswerStatus[selector] = true;
        }
        else
        {
            questionAnswerStatus.Add(selector, true);
        }
    }

    public int GetPlayerScore()
    {
        PlayerScore playerScore = FindObjectOfType<PlayerScore>();
        if (playerScore != null)
        {
            return playerScore.GetScore();
        }

        // If the PlayerScore component is not found, return 0 (or any default value)
        return 0;
    }
}


