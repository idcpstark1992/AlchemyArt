using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static  class SaveGame 
{
    public static void SaveGameDictionary (Dictionary<int, int> _inputData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/gameData.dat";
        FileStream fileStream = new FileStream(filePath, FileMode.Create);

        formatter.Serialize(fileStream, _inputData);
        fileStream.Dispose();
        fileStream.Close();
    }
    public static Dictionary<int,int> LoadGameDictionary () 
    {
        string filePath = "";
        Dictionary<int, int> m_toReturn = new Dictionary<int, int>();
        filePath = Application.persistentDataPath + "/gameData.dat";

        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            m_toReturn = formatter.Deserialize(fileStream) as Dictionary<int, int>;
            fileStream.Close();
            fileStream.Dispose();
        }
        else
        {
            Debug.LogWarning("No se encontraron datos guardados.");
        }
        return m_toReturn;
    }
    public static void DeleteData()
    {
        string  filePath = Application.persistentDataPath + "/gameData.dat";
        File.Delete(filePath);

    }
}
[System.Serializable]
public class GameData
{
    public int      numberOfAttempts;
    public string   sceneName;
    public bool     isCompleted;
}