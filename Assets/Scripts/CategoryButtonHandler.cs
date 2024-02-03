using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoryButtonHandler : MonoBehaviour
{
    public void OnTVCategorySelected()
    {
        AudioManager.Instance?.PlayClickSound();
        SessionManager.Instance.SetSelectedCategory("tv");
        SceneManager.LoadScene("tvSubcategoryScene");
    }

    public void OnMusicCategorySelected()
    {
        AudioManager.Instance?.PlayClickSound();
        SessionManager.Instance.SetSelectedCategory("music");
        SceneManager.LoadScene("musicSubcategoryScene");
    }

    // Continue adding methods for other categories
}
