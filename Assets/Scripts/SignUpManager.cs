using System.Collections;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Extensions; // Make sure this namespace is included

public class SignUpManager : MonoBehaviour
{
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public Button signUpButton;
    private FirebaseAuth auth;

    void Start()
    {
        // Ensure that the UI elements are assigned.
        if (emailInputField == null || passwordInputField == null || signUpButton == null)
        {
            Debug.LogError("UI elements are not assigned in the SignUpManager script.");
            return; // Exit early if the UI elements are not assigned.
        }

        InitializeFirebase();
        // It's safe to add the listener here because we've checked for null
        signUpButton.onClick.AddListener(() => StartCoroutine(SignUpCoroutine(emailInputField.text, passwordInputField.text)));
    }

    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + task.Exception);
                return;
            }
            // Only set the auth variable if Firebase dependencies are correctly resolved
            auth = FirebaseAuth.DefaultInstance;
        });
    }

    private IEnumerator SignUpCoroutine(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Debug.LogError("Email and password fields cannot be empty.");
            yield break;
        }

        var signUpTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);

        yield return new WaitUntil(() => signUpTask.IsCompleted);

        if (signUpTask.Exception != null)
        {
            Debug.LogError("SignUp failed: " + signUpTask.Exception);
            yield break;
        }

        Debug.Log("Firebase user created successfully.");
        // Optional: Transition to the next scene or update the UI to confirm the user has signed up
        // SceneManager.LoadScene("SignInScene");
    }
}
