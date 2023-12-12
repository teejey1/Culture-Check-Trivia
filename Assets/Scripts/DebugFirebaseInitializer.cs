using Firebase;
using Firebase.Extensions;
using UnityEngine;

public class DebugFirebaseInitializer : MonoBehaviour
{
    void Awake()
    {
        if (FirebaseApp.DefaultInstance == null)
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                if (task.Exception != null)
                {
                    Debug.LogError($"Failed to initialize Firebase: {task.Exception}");
                }
                else
                {
                    Debug.Log("Firebase initialized for debug.");
                }
            });
        }
    }
}
