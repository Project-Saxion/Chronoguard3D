using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button buttonToSelect;
    [SerializeField] private List<TextMeshProUGUI> levelTexts;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private GameObject gameManager;
    public MenuController _menuController;
    private InputAction _openMenu;

    private void Awake()
    {
        _menuController = new MenuController();
        upgradeUI.SetActive(false);
    }

    private void OnEnable()
    {
        _openMenu = _menuController.UI.OpenUpgradeMenu;
        _openMenu.Enable();
        _openMenu.performed += OpenMenu;
        checkMoney();
    }

    void OpenMenu(InputAction.CallbackContext context)
    {
        if (upgradeUI.activeSelf)
        {
            upgradeUI.SetActive(false);
        }
        else
        {
            buttonToSelect.Select();
            upgradeUI.SetActive(true);
        }
    }

    public void checkLevels()
    {
        List<int> levels = gameManager.GetComponent<UpgradeController>().getLevels();
        for(int i = 0; i < levels.Count; i++)
        {
            levelTexts[i].text = "Level: " + levels[i];
        }
    }

    public void checkMoney()
    {
        int money = gameManager.GetComponent<MoneyController>().GetMoney();
        moneyText.text = "€" + money.ToString("N0", new CultureInfo("fr-FR"));
    }
    // [SerializeField] private List<int> levels = new List<int>()
    // {
    //     0, // Base lvl
    //     0, // Turret t1
    //     0, // Turret t2
    //     0, // Turret t3
    //     0, // Turret t4
    //     0, // Player Attack lvl
    //     0, // Player HP lvl
    // };
    
}
