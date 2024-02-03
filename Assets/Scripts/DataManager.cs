using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int level;
    // Add more game state data here
}

public class DataManager
{
    private GameData gameData;
    private string dataFilePath = Path.Combine(Application.persistentDataPath, "GameData.json");

    public DataManager()
    {
        gameData = new GameData();
    }

    public void Save()
    {
        string dataToWrite = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(dataFilePath, dataToWrite);
    }

    public void Load()
    {
        if (File.Exists(dataFilePath))
        {
            string dataToLoad = File.ReadAllText(dataFilePath);
            gameData = JsonUtility.FromJson<GameData>(dataToLoad);
        }
        else
        {
            // Handle the case where the file doesn't exist
            Debug.Log("Save file not found");
        }
    }

    public GameData GetGameData()
    {
        return gameData;
    }

    // Methods to update gameData properties go here
}
