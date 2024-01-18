using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private int healPotionAmount = 10;
    [SerializeField] private List<int> costs = new List<int>()
    {
        // Base cost
        50,
        // Turret Amount cost
        50,
        // Turret damage cost
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
        1, // Base lvl
        1, // Turret lvl
        1, // Turret t1
        1, // Turret t2
        1, // Turret t3
        1, // Turret t4
        1, // Attack lvl
        1, // HP lvl
    };
    private List<(float, int)> turretData = new List<(float, int)>
    {
        (1, 6),
        (0.8f, 6),
        (0.8f, 10),
        (0.5f, 10)
    };

    [SerializeField] private List<float> startValues = new List<float>()
    {
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

    public void UpgradeBaseHp(int level)
    {
        if (costs[0] <= _moneyController.GetMoney())
        {
            int newHealth = Mathf.CeilToInt((float)(baseStartHealth * Math.Pow(multipliers[0], level)));
            _baseHealthController.SetHealth(newHealth);
            _baseHealthController.SetMaxHealth(newHealth); 
            
            _moneyController.RemoveMoney(costs[0]);
            levels[0] = level;
        }
    }

    public void UpgradeTurret(int level)
    {
        if (costs[1] <= _moneyController.GetMoney())
        {
            if (level - 1 < 4)
            {
                for (int i = 0; i < level; i++)
                {
                    turretList[i].SetActive(true);
                }
                _moneyController.RemoveMoney(costs[1]);
                levels[1] = level;
            }
        }
    } 
    public void UpgradeTurretDamage(int turretIndex, int level)
    {
        if (costs[2] <= _moneyController.GetMoney())
        {
            GameObject turret = turretList[turretIndex];
            turret.GetComponent<TurretController>().SetFireRate(turretData[level - 1].Item1);
            turret.GetComponent<ShootingSystem>().SetDamage(turretData[level - 1].Item2);
            _moneyController.RemoveMoney(costs[2]);
            levels[2 + turretIndex] = level;
        }
    }
    
    public void UpgradeAttack(int level)
    {
        if (costs[3] <= _moneyController.GetMoney())
        {
            float newAttack = (float)(playerStartAttack * Math.Pow(multipliers[2], level));
            _playerAttackController.attackModifier = newAttack;
            _moneyController.RemoveMoney(costs[3]);
            levels[6] = level;
        }
    }

    public void UpgradeHP(int level)
    {
        if (costs[4] <= _moneyController.GetMoney())
        {
            int newHealth = Mathf.CeilToInt((float)(playerStartHealth * Math.Pow(multipliers[3], level)));
            _playerHealthController.SetHealth(newHealth);
            _playerHealthController.SetMaxHealth(newHealth); 
            playerMaxHealth = Mathf.CeilToInt(newHealth); 
            _moneyController.RemoveMoney(costs[4]);
            levels[7] = level;
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

    public GameObject[] getTurrets()
    {
        return turretList;
    }

    public List<int> getLevels()
    {
        return levels;
    }
}

