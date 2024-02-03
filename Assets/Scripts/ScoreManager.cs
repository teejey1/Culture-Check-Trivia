using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        // Retrieve the final score from SessionManager and display it
        if (SessionManager.Instance != null)
        {
            scoreText.text = "Your Score: " + SessionManager.Instance.Score.ToString();
        }
        else
        {
            Debug.LogError("SessionManager instance not found.");
            scoreText.text = "Your Score: Error";
        }
    }
}
