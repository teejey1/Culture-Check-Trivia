using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordToggle : MonoBehaviour
{
    public TMP_InputField passwordInputField;
    public Button visibilityToggleButton;
    private bool isPasswordVisible;

    void Start()
    {
        // Add a listener to your toggle button
        visibilityToggleButton.onClick.AddListener(TogglePasswordVisibility);
    }

    private void TogglePasswordVisibility()
    {
        isPasswordVisible = !isPasswordVisible;
        passwordInputField.contentType = isPasswordVisible ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        passwordInputField.ForceLabelUpdate();

        // If the password is visible, move the caret to the end of the text
        if (isPasswordVisible)
        {
            passwordInputField.ActivateInputField();
            passwordInputField.Select();
        }
    }
}
