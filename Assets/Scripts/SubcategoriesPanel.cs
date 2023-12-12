using UnityEngine;
using UnityEngine.UI;  // This is required for UI components like Button
using TMPro;

public class SubcategoriesPanel : MonoBehaviour
{
    public GameObject subcategoryButtonPrefab; // Assign in the inspector
    public Transform buttonContainer; // Assign the container where buttons will be instantiated
    public Button backButton; // Assign in the inspector

    private void Awake()
    {
        backButton.onClick.AddListener(HidePanel);
    }

    public void PopulateSubcategories(string[] subcategories)
    {
        foreach (string subcategory in subcategories)
        {
            GameObject buttonObj = Instantiate(subcategoryButtonPrefab, buttonContainer);
            TMP_Text buttonText = buttonObj.GetComponentInChildren<TMP_Text>();
            buttonText.text = subcategory;
            // Additional setup for the button can be done here
        }
    }

    private void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
