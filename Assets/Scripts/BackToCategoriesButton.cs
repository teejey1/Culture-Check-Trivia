using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToCategoriesButton : MonoBehaviour
{
    public void LoadCategoriesScene()
    {
        // Play the click sound using the AudioManager before changing the scene
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayClickSound();
        }

        // Load the Categories Scene
        SceneManager.LoadScene("CategoriesScene"); // Replace with your actual categories scene name
    }
}
