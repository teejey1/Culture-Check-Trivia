using UnityEngine;
using Firebase;
using Firebase.Extensions;
using UnityEngine.SceneManagement;

public class FirebaseInitializer : MonoBehaviour
{
    public string nextSceneName = "LoginScene"; // Change to your next scene's name

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {task.Exception}");
                // Optionally, you can add logic to handle initialization failure
            }
            else if (task.Result == DependencyStatus.Available)
            {
                // Firebase is ready for use here
                FirebaseApp app = FirebaseApp.DefaultInstance;
                OnFirebaseInitialized();
            }
            else
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {task.Result}");
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    private void OnFirebaseInitialized()
    {
        // Firebase is ready, transition to the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
