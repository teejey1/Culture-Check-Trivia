using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(() => {
            AudioManager.Instance?.PlayClickSound();
            SceneManager.LoadScene("CategoriesScene");
        });
    }
}
