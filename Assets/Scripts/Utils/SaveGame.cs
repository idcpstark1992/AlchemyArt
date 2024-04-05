using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static  class SaveGame 
{
    public static void SaveGameDictionary (Dictionary<int, int> _inputData)
    {
        BinaryFormatter formatter = new ();
        string filePath = Application.persistentDataPath + "/gameData.dat";
        FileStream fileStream = new(filePath, FileMode.Create);

        formatter.Serialize(fileStream, _inputData);
        fileStream.Dispose();
        fileStream.Close();
    }
    public static Dictionary<int,int> LoadGameDictionary () 
    {
        Dictionary<int, int> m_toReturn = new ();
        string filePath = Application.persistentDataPath + "/gameData.dat";

        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new ();
            FileStream fileStream = new (filePath, FileMode.Open);
            m_toReturn = formatter.Deserialize(fileStream) as Dictionary<int, int>;
            fileStream.Close();
            fileStream.Dispose();
        }
        else
        {
            Debug.LogWarning("No Data found !");
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