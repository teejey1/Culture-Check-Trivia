using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance { get; private set; }

    public string SelectedCategory { get; private set; }
    public string SelectedSubcategory { get; private set; }
    public int Score { get; private set; } // Variable to hold the score

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSelectedCategory(string category)
    {
        SelectedCategory = category;
    }

    public void SetSelectedSubcategory(string subcategory)
    {
        SelectedSubcategory = subcategory;
    }

    public void AddScore(int scoreToAdd)
    {
        Score += scoreToAdd;
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void SetScore(int finalScore)
    {
        Score = finalScore;
    }
}
