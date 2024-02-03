using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class LoadingSceneController : MonoBehaviour
{
    public Slider loadingBar;
    public Text loadingText;

    private void Start()
    {
        // Call the LoadAsyncOperation function
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        // Start the async scene loading
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync("LoginScene"); // Replace with your game scene name

        while (!gameLevel.isDone)
        {
            // Take the progress bar fill amount and display it to the user
            loadingBar.value = gameLevel.progress;
            loadingText.text = "Loading... " + (gameLevel.progress * 100) + "%";

            // Yield return null will make the coroutine wait until the next frame
            yield return null;
        }
    }
}
