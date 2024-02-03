using Firebase;
using Firebase.Firestore;
using Firebase.Auth;
using UnityEngine;

public class FirebaseInitializer : MonoBehaviour
{
    public static FirebaseInitializer Instance { get; private set; }
    private FirebaseFirestore database;
    private FirebaseAuth auth;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeFirebase();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                // Firebase Firestore initialization
                database = FirebaseFirestore.DefaultInstance;
                Debug.Log("Firebase Firestore is initialized and ready to use.");

                // Firebase Authentication initialization
                auth = FirebaseAuth.DefaultInstance;
                Debug.Log("Firebase Auth is initialized and ready to use.");

                // Optional: Add more initialization code for other Firebase services here, if needed
            }
            else
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            }
        });
    }

    // Optional: Implement additional methods related to Firestore and Auth operations
}
