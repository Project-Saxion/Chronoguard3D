using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button buttonToSelect;
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
}
