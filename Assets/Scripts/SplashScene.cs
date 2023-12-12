using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float delayTime = 3f; // Time in seconds to display the splash screen
    public string nextSceneName = "LoginScene"; // Replace with your next scene name

    void Start()
    {
        Invoke("LoadNextScene", delayTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
