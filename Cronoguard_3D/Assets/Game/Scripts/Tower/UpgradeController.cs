using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private int healPotionAmount = 10;
    [SerializeField] private List<int> costs = new List<int>()
    {
        // Base cost
        50,
        // Turret First Upgrade cost
        50,
        // Turret DMG cost
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
        // Attack multiplier
        1.25,
        // HP multiplier
        1.25
    };

    [SerializeField] private List<int> levels = new List<int>()
    {
        0, // Base lvl
        0, // Turret t1
        0, // Turret t2
        0, // Turret t3
        0, // Turret t4
        0, // Player Attack lvl
        0, // Player HP lvl
    }; 
    private List<(float, int)> turretData = new List<(float, int)>
    {
        (1, 6),
        (0.8f, 6),
        (0.8f, 10),
        (0.5f, 10)
    };

    private List<(double, double, double)> turretTransformData = new List<(double, double, double)>
    {
        (5, 7.38, 5.9),    // T1 SpaceBase
        (5, 7.38, -5.5),   // T2 SpaceBase
        (-5, 7.38, 5.9),   // T3 SpaceBase
        (-5, 7.38, -5.5),  // T4 SpaceBase
        (6, 5.08, 6.5),    // T1 WarBase
        (6, 5.08, -6.1),   // T2 WarBase
        (-6.6, 5.08, 6.5), // T3 WarBase
        (-6.6, 5.08, -6.1),// T4 WarBase
        (6.4, 2.8, 6.2),   // T1 WesternBase
        (6.4, 2.8, -5.8),  // T2 WesternBase
        (-6.2, 2.8, 6.2),  // T3 WesternBase
        (-6.2, 2.8, -5.8)  // T4 WesternBase
        
    };
    
    private MoneyController _moneyController;
    private HealthController _playerHealthController;
    private PlayerController _playerAttackController;
    public float playerStartAttack;
    public int playerStartHealth;
    public int playerMaxHealth;
    
    private HealthController _baseHealthController;
    private int baseStartHealth;
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
        _playerAttackController = player.GetComponent<PlayerController>();
        _playerHealthController = player.GetComponent<HealthController>();
        playerStartHealth = _playerHealthController.GetMaxHealth();
        playerMaxHealth = _playerHealthController.GetMaxHealth();
        playerStartAttack =  _playerAttackController.attackModifier;

        tower = GameObject.FindGameObjectWithTag("Base");
        _baseHealthController = tower.GetComponent<HealthController>();
        baseStartHealth = _baseHealthController.GetMaxHealth();

        turretList = GameObject.FindGameObjectsWithTag("Turret");
        for (int i = 0; i < turretList.Length; i++)
        {
            GameObject turret = turretList[i];
            turret.SetActive(false);
        }
    }

    public void UpgradeBaseHp()
    {
        UpgradeBaseHp(levels[0] + 1);
    }

    public void UpgradeBaseHp(int level)
    {
        if (costs[0] <= _moneyController.GetMoney())
        {
            int newHealth = Mathf.CeilToInt((float)(baseStartHealth * Math.Pow(multipliers[0], level)));
            _baseHealthController.SetMaxHealth(newHealth); 
            
            _moneyController.RemoveMoney(costs[0]);
            levels[0] = level;
        }
    }

    public void UpgradeTurret(int turretIndex)
    {
        UpgradeTurret(turretIndex, levels[1 + turretIndex] + 1);
    }
    
    public void UpgradeTurret(int turretIndex, int level)
    {
        if (level == 1)
        {
            if (costs[1] <= _moneyController.GetMoney())
            {
                turretList[turretIndex].SetActive(true);
                _moneyController.RemoveMoney(costs[1]);
                levels[1 + turretIndex] = level;
            }
        }else if (level > 1 && level <= 5)
        {
            if (costs[2] <= _moneyController.GetMoney())
            {
                turretList[turretIndex].GetComponent<TurretController>().SetFireRate(turretData[level - 2].Item1);
                turretList[turretIndex].GetComponent<ShootingSystem>().SetDamage(turretData[level - 2].Item2);
                _moneyController.RemoveMoney(costs[2]);
                levels[1 + turretIndex] = level;
            }
        }
    }

    public void UpgradeAttack()
    {
        UpgradeAttack(levels[5] + 1);
    }
    
    public void UpgradeAttack(int level)
    {
        if (costs[3] <= _moneyController.GetMoney())
        {
            float newAttack = (float)(playerStartAttack * Math.Pow(multipliers[2], level));
            _playerAttackController.attackModifier = newAttack;
            _moneyController.RemoveMoney(costs[3]);
            levels[5] = level;
        }
    }

    public void UpgradeHp()
    {
        UpgradeHp(levels[6] + 1);
    }

    public void UpgradeHp(int level)
    {
        if (costs[4] <= _moneyController.GetMoney())
        {
            int newHealth = Mathf.CeilToInt((float)(playerStartHealth * Math.Pow(multipliers[3], level)));
            _playerHealthController.SetMaxHealth(newHealth); 
            playerMaxHealth = Mathf.CeilToInt(newHealth); 
            _moneyController.RemoveMoney(costs[4]);
            levels[6] = level;
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

    public GameObject[] GetTurrets()
    {
        return turretList;
    }

    public List<int> getLevels()
    {
        return levels;
    }
}

