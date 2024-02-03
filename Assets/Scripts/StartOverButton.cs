using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOverButton : MonoBehaviour
{
    public void OnStartOverClicked()
    {
        // Play click sound using AudioManager
        AudioManager.Instance?.PlayClickSound();

        // Logic to 'start over' in the game
        SceneManager.LoadScene("CategoriesScene");
    }
}
