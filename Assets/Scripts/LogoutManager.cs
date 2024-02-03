using Firebase.Auth;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoutManager : MonoBehaviour
{
    public void LogOut()
    {
        FirebaseAuth.DefaultInstance.SignOut();
        Debug.Log("User has been signed out.");

        // Optionally, redirect to the login scene or any other scene
        SceneManager.LoadScene("LoginScene"); // Replace with your login scene name
    }
}
