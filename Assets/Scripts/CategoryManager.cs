using UnityEngine;

public class CategoryManager : MonoBehaviour
{
    public GameObject subcategoryButtonPrefab; // Assign in the inspector
    public GameObject subcategoriesPanel; // Assign your subcategories panel here
    public Transform subcategoryButtonContainer; // Assign the container inside the panel for buttons

    // ... Rest of your script ...

    private void ShowSubcategoriesPanel(string subcategoryName)
    {
        subcategoriesPanel.SetActive(true); // Activate the subcategories panel

        // Clear existing buttons if any
        foreach (Transform child in subcategoryButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // Instantiate subcategory buttons
        // Example: If subcategoryName == "Hip Hop", instantiate buttons for "2009 - 2020", "1990 - 2000"
        // Populate each button with the respective subcategory name and action
    }

    // ... Rest of your script ...
}
