using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
            {
                Debug.LogError("GameManager is null");
            }
            return _instance;
        }
    }
    
    private void Awake()
    {
        _instance = this;
    }

    [SerializeField] private Transform playerRespawnPosition;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject respawnOverlay;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private RespawnController respawnController;
    
    private HealthController playerHealthController;

    private void Start()
    {
        playerHealthController = player.GetComponent<HealthController>();
    }
    
    public void GameOver()
    {
        player.SetActive(false);
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void PlayerDeath()
    {
        cameraController.SetFollowing(false);
        player.SetActive(false);
        respawnOverlay.SetActive(true);
        respawnController.StartCooldown();
        //playerInput.Disable();
    }
    
    public void RespawnPlayer()
    {
        player.SetActive(true);
        player.transform.position = playerRespawnPosition.position;
        respawnOverlay.SetActive(false);
        //playerInput.Enable();
        cameraController.SetFollowing(true);
        playerHealthController.Heal(playerHealthController.GetMaxHealth());
    }


    public void ExitApplication()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        //save game
        SceneManager.LoadScene(0);
    }

    public void DeleteSave()
    {
        SavingGame savingGame = GameObject.FindGameObjectWithTag("DontDestroy").GetComponent<SavingGame>();
        savingGame.DeleteGame(savingGame.currentSave);
    }
    
}
