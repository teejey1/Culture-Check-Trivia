using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Separate references for sign-in and sign-up input fields
    public TMP_InputField signInEmailInputField;
    public TMP_InputField signInPasswordInputField;
    public TMP_InputField signUpEmailInputField;
    public TMP_InputField signUpPasswordInputField;

    public GameObject signInPanel;
    public GameObject signUpPanel;
    public TextMeshProUGUI feedbackText;

    private AuthManager authManager;

    void Start()
    {
        authManager = FindObjectOfType<AuthManager>();
        if (authManager == null)
        {
            Debug.LogError("AuthManager not found in the scene!");
        }
    }

    public void ShowSignInPanel()
    {
        signInPanel.SetActive(true);
        signUpPanel.SetActive(false);
    }

    public void ShowSignUpPanel()
    {
        signInPanel.SetActive(false);
        signUpPanel.SetActive(true);
    }

    public void OnSignInButtonClicked()
    {
        string email = signInEmailInputField.text;
        string password = signInPasswordInputField.text;
        authManager.SignInWithEmailPassword(email, password, UpdateFeedbackText);
    }

    public void OnSignUpButtonClicked()
    {
        string email = signUpEmailInputField.text;
        string password = signUpPasswordInputField.text;
        authManager.SignUpWithEmailPassword(email, password, UpdateFeedbackText);
    }

    private void UpdateFeedbackText(bool success, string message)
    {
        feedbackText.text = message;
        if (success)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
