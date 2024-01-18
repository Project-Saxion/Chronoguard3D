using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    [SerializeField] private Image healthbar;
    [SerializeField] private HealthController healthController;
    [SerializeField] private TextMeshProUGUI healthbarText;

    private int fullHealth;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        updateHealthBar();
    }

    void updateHealthBar()
    {
        fullHealth = healthController.GetMaxHealth();
        health = healthController.GetHealth();
        healthbar.fillAmount = ((float) health / fullHealth);
        healthbarText.text = health + "/" + fullHealth;

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
