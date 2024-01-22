using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private Button buttonToSelect;
    [SerializeField] private Scene MainMenuScene;
    public MenuController _menuController;
    private InputAction _openMenu;
    // Start is called before the first frame update
    private void Awake()
    {
        _menuController = new MenuController();
        menuUI.SetActive(false);
    }

    private void OnEnable()
    {
        _openMenu = _menuController.UI.OpenMainMenu;
        _openMenu.Enable();
        _openMenu.performed += OpenMenu;
    }

    void OpenMenu(InputAction.CallbackContext context)
    {
        if (menuUI.activeSelf)
        {
            menuUI.SetActive(false);
        }
        else
        {
            buttonToSelect.Select();
            menuUI.SetActive(true);
        }
    }

    public void Continue()
    {
        menuUI.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("Main menu");
    }
    public void loadGame()
    {
        
    }

    public void newGame()
    {
        
    }

    public void exit()
    {
        Application.Quit();
    }
}
