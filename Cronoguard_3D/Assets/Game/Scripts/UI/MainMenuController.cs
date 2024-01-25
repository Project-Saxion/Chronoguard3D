using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] SavingGame savingManager;
    
    public void StartGame(string save)
    {
        savingManager.currentSave = save;
        SceneManager.LoadScene(1);
    }    

    public void exit()
    {
        Application.Quit();
    }


    bool TryGetSave(string save)
    {
        if (File.Exists(Application.persistentDataPath + "/" + name + ".save"))
        {
            return true;
        }

        return false;
    }
}
