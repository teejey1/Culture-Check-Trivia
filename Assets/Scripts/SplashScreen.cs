using UnityEngine;
using System.Collections;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float delayTime = 3f;
    private FirebaseAuth auth;

    void Start()
    {
        StartCoroutine(InitializeAndCheckUser());
    }

    IEnumerator InitializeAndCheckUser()
    {
        yield return new WaitForSeconds(delayTime);
        auth = FirebaseAuth.DefaultInstance;

        if (auth.CurrentUser != null)
        {
            // User is signed in
            SceneManager.LoadScene("MainMenuScene");
        }
        else
        {
            // No user signed in
            SceneManager.LoadScene("LoadingScene");
        }
    }
}