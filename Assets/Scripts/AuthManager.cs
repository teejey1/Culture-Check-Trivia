using Firebase.Auth;
using UnityEngine;
using UnityEngine.SceneManagement;
using System; // For the Action delegate
using Firebase.Extensions;

public class AuthManager : MonoBehaviour
{
    public static AuthManager Instance { get; private set; }
    private FirebaseAuth auth;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeFirebase();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public bool IsUserLoggedIn()
    {
        return auth.CurrentUser != null;
    }

    public void SignInWithEmailPassword(string email, string password, Action<bool, string> callback)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailPassword failed: " + task.Exception);
                callback(false, task.Exception?.Message);
            }
            else
            {
                Debug.Log("SignInWithEmailPassword successful!");
                callback(true, "Sign-in successful.");
            }
        });
    }

    // Removed the username parameter as it's not used for Firebase Auth email/password sign-up
    public void SignUpWithEmailPassword(string email, string password, Action<bool, string> callback)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("SignUpWithEmailPassword failed: " + task.Exception);
                callback(false, task.Exception?.Message);
            }
            else
            {
                Debug.Log("SignUpWithEmailPassword successful!");
                callback(true, "Sign-up successful.");
            }
        });
    }

    public void SignOut()
    {
        auth.SignOut();
        Debug.Log("User signed out successfully.");
        SceneManager.LoadScene("LoginScene");
    }
}
