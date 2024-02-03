using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLoginScene()
    {
        SceneManager.LoadScene("LoginScene"); // Replace with your actual login scene name
    }

    public void LoadSignUpScene()
    {
        SceneManager.LoadScene("SignUpScene"); // Replace with your actual sign-up scene name
    }

    // You can add more methods to load other scenes as needed.
}
