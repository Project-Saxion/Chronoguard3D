using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] SavingGame savingManager;
    [SerializeField] private TextMeshProUGUI[] slotText;

    private void Start()
    {
        SetSlotText();
    }

    public void StartGame(string save)
    {
        savingManager.currentSave = save;
        SceneManager.LoadScene(1);
    }    

    public void Exit()
    {
        Application.Quit();
    }

    public void SetSlotText()
    {
        for (int i = 0; i < 3; i++)
        {
            if (savingManager.TryGetSave("slot" + (i+1)))
            {
                slotText[i].text = "Load save " + (i + 1);
            }
            else
            {
                slotText[i].text = "Start New Game";
            }
        }
    }
}
