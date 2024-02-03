using UnityEngine;
using UnityEngine.SceneManagement;

public class SubcategoryButtonHandler : MonoBehaviour
{
    public void OnSubcategorySelected(string subcategoryName)
    {
        AudioManager.Instance?.PlayClickSound();
        SessionManager.Instance.SetSelectedSubcategory(subcategoryName);
        SceneManager.LoadScene("TriviaScene");
    }
}
