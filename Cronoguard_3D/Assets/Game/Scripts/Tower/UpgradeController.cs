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
        // Turret Firerate multiplier
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
    private List<(int, int)> turretData = new List<(int, int)>
    {
        (1, 15),
        (4, 10),
        (5, 15),
        (10, 10)
    };

    [SerializeField] private List<float> startValues = new List<float>()
    {
    };

    [SerializeField] private GameObject TurretPrefab;
    [SerializeField] private GameObject baseObject;
    private MoneyController _moneyController;
    private HealthController _playerHealthController;
    private Attack _playerAttackController;
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
        _playerAttackController = player.GetComponent<Attack>();
        _playerHealthController = player.GetComponent<HealthController>();
        playerMaxHealth = _playerHealthController.GetMaxHealth();

        tower = GameObject.FindGameObjectWithTag("Base");
        _baseHealthController = tower.GetComponent<HealthController>();
        baseStartHealth = _baseHealthController.GetMaxHealth();

        turretList = GameObject.FindGameObjectsWithTag("Turret");
        UpgradeTurret(2);
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
            if (level < 4)
            {
                for (int i = 0; i < level; i++)
                {
                    turretList[i].SetActive(true);
                }
                _moneyController.RemoveMoney(costs[1]);
                levels[0] = level;
            }
        }
    } 
    public void UpgradeTurretDamage(int turretIndex)
    {
        if (costs[2] <= _moneyController.GetMoney())
        {
            GameObject turret = turretList[turretIndex];
            turret.GetComponent<ShootingSystem>().SetDamage(Mathf.RoundToInt((float)(turret.GetComponent<ShootingSystem>().GetDamage()*multipliers[1])));
            _moneyController.RemoveMoney(costs[1]);
        }
    }

    public void UpgradeTurretFirerate(int turretIndex)
    {
        if (costs[3] <= _moneyController.GetMoney())
        {
            GameObject turret = turretList[turretIndex];
            turret.GetComponent<TurretController>().SetFireRate(Mathf.RoundToInt((float)(turret.GetComponent<TurretController>().GetFireRate()*multipliers[2])));    
            _moneyController.RemoveMoney(costs[2]);
        }
    }
    
    public void UpgradeAttack(int level)
    {
        if (costs[4] <= _moneyController.GetMoney())
        {
            _playerAttackController.SetModifier((float) (_playerAttackController.GetModifier()*1.25));
        }
    }

    public void UpgradeHP()
    {
        if (costs[5] <= _moneyController.GetMoney())
        {
            _playerHealthController.SetHealth(Mathf.CeilToInt((float)(playerMaxHealth * multipliers[4])));
            _playerHealthController.SetMaxHealth(Mathf.CeilToInt((float)(playerMaxHealth * multipliers[4]))); 
            playerMaxHealth = Mathf.CeilToInt((float)(playerMaxHealth * multipliers[4])); 
            _moneyController.RemoveMoney(costs[4]);
        }
    }

    public void HealPotion()
    {
        if (costs[6] <= _moneyController.GetMoney())
        {
            _playerHealthController.Heal(healPotionAmount);
            _moneyController.RemoveMoney(costs[5]);
        }
        
    }
}

