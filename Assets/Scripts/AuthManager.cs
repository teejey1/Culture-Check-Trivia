using System.Collections;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using TMPro; // Using TextMeshPro
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{
    public TMP_InputField emailInputField;  // Changed to TMP_InputField for TextMeshPro
    public TMP_InputField passwordInputField;  // Changed to TMP_InputField for TextMeshPro
    public Button signUpButton;
    private FirebaseAuth auth;

    void Start()
    {
        InitializeFirebase();
    }

    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogError("Failed to initialize Firebase with the following errors: " + task.Exception.ToString());
                return;
            }
            auth = FirebaseAuth.DefaultInstance;

            // Attach the listener here to ensure auth is initialized
            signUpButton.onClick.AddListener(() => StartCoroutine(SignUpCoroutine(emailInputField.text, passwordInputField.text)));
        });
    }

    private IEnumerator SignUpCoroutine(string email, string password)
    {
        if (auth == null)
        {
            Debug.LogError("FirebaseAuth not initialized.");
            yield break;
        }

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Debug.LogError("Email and password fields cannot be empty.");
            yield break;
        }

        var authTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);

        yield return new WaitUntil(() => authTask.IsCompleted);

        if (authTask.Exception != null)
        {
            FirebaseException firebaseEx = authTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
            Debug.LogError("SignUp failed with error: " + errorCode);
            yield break;
        }

        FirebaseUser newUser = authTask.Result.User;
        Debug.LogFormat("Firebase user created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);

        SceneManager.LoadScene("NextSceneName"); // Replace with your scene name
    }
}
