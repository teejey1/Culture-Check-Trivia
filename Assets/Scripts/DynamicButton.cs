using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DynamicButton : MonoBehaviour
{
    public TMP_Text buttonText; // Assume this is assigned in the inspector
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Initialize(string text, UnityAction action)
    {
        buttonText.text = text;
        button.onClick.AddListener(action);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }
}
