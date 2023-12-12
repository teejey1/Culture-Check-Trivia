using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public TMP_Text playButtonText; // If you want to change the button text dynamically
    public Button playButton;

    void Start()
    {
        // Add a click listener to the play button which will call the PlayGame function
        playButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        // Load the CategoriesScene
        SceneManager.LoadScene("CategoriesScene");
    }
}
