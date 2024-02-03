using UnityEngine;
using UnityEngine.UI; // For UI Text

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    [SerializeField] private Text coinText; // Assign in inspector
    private int coinCount;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        LoadCoins();
    }

    void LoadCoins()
    {
        // Load coin count from PlayerPrefs or your chosen method
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        UpdateCoinText();
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinText();
        SaveCoins();
    }

    public void SpendCoins(int amount)
    {
        if (coinCount >= amount)
        {
            coinCount -= amount;
            UpdateCoinText();
            SaveCoins();
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }

    void UpdateCoinText()
    {
        if (coinText != null)
            coinText.text = "Coins: " + coinCount;
    }

    void SaveCoins()
    {
        PlayerPrefs.SetInt("CoinCount", coinCount);
    }
}
