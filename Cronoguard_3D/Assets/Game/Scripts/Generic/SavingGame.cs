using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Game.Scripts.Generic;
using UnityEngine;

public class SavingGame : MonoBehaviour
{
    // private void Start()
    // {
    //     DeleteGame("testFile");
    //     SaveGame("testFile");
    // }

    public string currentSave;

    public void SaveGame(string name)
    {
        if (File.Exists(Application.persistentDataPath + "/" + name + ".save"))
        {
            Debug.Log("name already exists");
            return;
        }
        Save save = new Save();
        
        
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + name + ".save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log(Application.persistentDataPath);
        Debug.Log("Game Saved");
    }

    public void LoadGame(string name)
    {
        if (File.Exists(Application.persistentDataPath + "/" + name + ".save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + name + ".save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    public void DeleteGame(string name)
    {
        if (File.Exists(Application.persistentDataPath + "/" + name + ".save"))
        {
            File.Delete(Application.persistentDataPath + "/" + name + ".save");
            Debug.Log("Game Deleted");
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}