using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private int healPotionAmount = 10;
    [SerializeField] private List<int> costs = new List<int>()
    {
        // Base cost
        50,
        // Turret damage cost
        50,
        // Turret firerate cost
        50,
        // Attack cost
        50,
        // HP cost
        50,
        // HP Potion cost
        50
    };

    [SerializeField] private List<double> multipliers = new List<double>()
    {
        // Base multiplier
        1.25,
        // Turret Damage multiplier
        1.25,
        // Turret Firerate multiplier
        1.25,
        // Attack multiplier
        1.25,
        // HP multiplier
        1.25
    };
    private MoneyController _moneyController;
    private HealthController _playerHealthController;
    public int playerMaxHealth;
    
    private HealthController _baseHealthController;
    private int baseMaxHealth;

    private TurretController _turretController;

    private GameObject player;
    private GameObject tower;
    private GameObject[] turretList;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _moneyController = GetComponent<MoneyController>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        _playerHealthController = player.GetComponent<HealthController>();
        playerMaxHealth = _playerHealthController.GetMaxHealth();

        tower = GameObject.FindGameObjectWithTag("Base");
        _baseHealthController = tower.GetComponent<HealthController>();
        baseMaxHealth = _baseHealthController.GetMaxHealth();

        turretList = GameObject.FindGameObjectsWithTag("Turret");
    }

    public void UpgradeBase()
    {
        if (costs[0] <= _moneyController.GetMoney())
        {
            _baseHealthController.SetHealth(Mathf.CeilToInt((float)(baseMaxHealth * multipliers[0])));
            _baseHealthController.SetMaxHealth(Mathf.CeilToInt((float)(baseMaxHealth * multipliers[0]))); 
            baseMaxHealth = Mathf.CeilToInt((float)(baseMaxHealth * multipliers[0])); 
            _moneyController.RemoveMoney(costs[0]);
        }
        
    }

    public void UpgradeTurretDamage(int turretIndex)
    {
        if (costs[1] <= _moneyController.GetMoney())
        {
            GameObject turret = turretList[turretIndex];
            turret.GetComponent<ShootingSystem>().SetDamage(Mathf.RoundToInt((float)(turret.GetComponent<ShootingSystem>().GetDamage()*multipliers[1])));
            _moneyController.RemoveMoney(costs[1]);
        }
    }

    public void UpgradeTurretFirerate(int turretIndex)
    {
        if (costs[2] <= _moneyController.GetMoney())
        {
            GameObject turret = turretList[turretIndex];
            turret.GetComponent<TurretController>().SetFireRate(Mathf.RoundToInt((float)(turret.GetComponent<TurretController>().GetFireRate()*multipliers[2])));    
            _moneyController.RemoveMoney(costs[2]);
        }
    }
    
    // public void UpgradeAttack(int level)
    // {
    //     
    // }

    public void UpgradeHP()
    {
        if (costs[4] <= _moneyController.GetMoney())
        {
            _playerHealthController.SetHealth(Mathf.CeilToInt((float)(playerMaxHealth * multipliers[4])));
            _playerHealthController.SetMaxHealth(Mathf.CeilToInt((float)(playerMaxHealth * multipliers[4]))); 
            playerMaxHealth = Mathf.CeilToInt((float)(playerMaxHealth * multipliers[4])); 
            _moneyController.RemoveMoney(costs[4]);
        }
    }

    public void HealPotion()
    {
        if (costs[5] <= _moneyController.GetMoney())
        {
            _playerHealthController.Heal(healPotionAmount);
            _moneyController.RemoveMoney(costs[5]);
        }
        
    }
}

