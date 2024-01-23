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
        1.75,
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

    [SerializeField] private List<GameObject> Base = new List<GameObject>()
    {
        
    };

    [SerializeField] private List<GameObject> turretGraphics = new List<GameObject>()
    {
        
    };

    [SerializeField] private List<GameObject> ListOfTurrets = new List<GameObject>()
    {

    };
    
    private List<(float, int)> turretData = new List<(float, int)>
    {
        (1, 6),
        (0.8f, 6),
        (0.8f, 10),
        (0.5f, 10)
    };

    private List<(float, float, float)> turretTransformData = new List<(float, float, float)>
    {
        (2.7f, 4.45f, 2.7f),  // T1 PirateBase 
        (2.7f, 4.45f, -2.7f), // T2 PirateBase
        (-2.7f, 4.45f, 2.7f), // T3 PirateBase
        (-2.7f, 4.45f, -2.7f),// T4 PirateBase
        (6.4f, 2.8f, 6.2f),   // T1 WesternBase
        (6.4f, 2.8f, -5.8f),  // T2 WesternBase
        (-6.2f, 2.8f, 6.2f),  // T3 WesternBase
        (-6.2f, 2.8f, -5.8f), // T4 WesternBase
        (6f, 5.08f, 6.5f),    // T1 WarBase
        (6f, 5.08f, -6.1f),   // T2 WarBase
        (-6.6f, 5.08f, 6.5f), // T3 WarBase
        (-6.6f, 5.08f, -6.1f),// T4 WarBase
        (5f, 7.38f, 5.9f),    // T1 SpaceBase
        (5f, 7.38f, -5.5f),   // T2 SpaceBase
        (-5f, 7.38f, 5.9f),   // T3 SpaceBase
        (-5f, 7.38f, -5.5f),  // T4 SpaceBase
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
    // private GameObject[] turretList;
    
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
        
        for (int i = 0; i < ListOfTurrets.Count; i++)
        {
            GameObject turret = ListOfTurrets[i];
            turret.SetActive(false);
        }
    }

    public void UpgradeBaseHp()
    {
        UpgradeBaseHp(levels[0] + 1);
    }

    public void UpgradeBaseHp(int level)
    {
        if (level < 4)
        {
            if (costs[0] <= _moneyController.GetMoney())
            { 
                int newHealth = Mathf.CeilToInt((float)(baseStartHealth * Math.Pow(multipliers[0], level)));
                _baseHealthController.SetMaxHealth(newHealth); 
                upgradeBaseGraphics(level);
                
                _moneyController.RemoveMoney(costs[0]);
                levels[0] = level;
            }
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
                upgradeTurretGraphics(turretIndex, level);
                ListOfTurrets[turretIndex].SetActive(true);
                _moneyController.RemoveMoney(costs[1]);
                levels[1 + turretIndex] = level;
            }
        }else if (level > 1 && level <= 4)
        {
            if (costs[2] <= _moneyController.GetMoney())
            {
                upgradeTurretGraphics(turretIndex, level);
                ListOfTurrets[turretIndex].GetComponent<TurretController>().SetFireRate(turretData[level - 2].Item1);
                ListOfTurrets[turretIndex].GetComponent<ShootingSystem>().SetDamage(turretData[level - 2].Item2);
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
        if (level < 4)
        {
            if (costs[3] <= _moneyController.GetMoney())
            {
                float newAttack = (float)(playerStartAttack * Math.Pow(multipliers[2], level));
                _playerAttackController.attackModifier = newAttack;
                _moneyController.RemoveMoney(costs[3]);
                levels[5] = level;
            }
        }
    }

    public void UpgradeHp()
    {
        UpgradeHp(levels[6] + 1);
    }

    public void UpgradeHp(int level)
    {
        if (level < 4)
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
        return ListOfTurrets.ToArray();
    }

    public List<int> getLevels()
    {
        return levels;
    }

    public void upgradeBaseGraphics(int level)
    {
          foreach (GameObject baseGameObject in Base)
          {
              baseGameObject.SetActive(false);
          }
          Base[level].SetActive(true);
          for (int i = 0; i < 4; i++)
          {
              ListOfTurrets[i].transform.localPosition = new Vector3(turretTransformData[level * 4 + i].Item1,turretTransformData[level * 4 + i].Item2, turretTransformData[level * 4 + i].Item3);
          }

    }

    public void upgradeTurretGraphics(int turretIndex, int level)
    {
        if (level > 0 && level < 5)
        {
            if (level != 1)
            {
                turretGraphics[turretIndex*4 + level - 2].SetActive(false);
            }
            turretGraphics[(turretIndex*4) + level -1].SetActive(true);
        }
    }
}

