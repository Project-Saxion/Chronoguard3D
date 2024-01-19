using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Game.Scripts.Generic;
using UnityEngine;

public class SavingGame : MonoBehaviour
{
    public List<string> GetSaveGames()
    {
        return Directory.GetFiles(Application.persistentDataPath)
            .Select(item => item.Split("\\")[item.Split("\\").Length - 1])
            .Select(item => item.Substring(0, item.Length - 5))
            .ToList();
    }

    public void printSaveGames()
    {
        foreach (var savegame in GetSaveGames())
        {
            Debug.Log(savegame);
        }
    }

    public string currentSave;

    public void SaveGame(string name)
    {
        if (File.Exists(Application.persistentDataPath + "/" + name + ".save"))
        {
            Debug.Log("name already exists");
            return;
        }
        Save save = new Save();

        UpgradeController upgradeController = GetComponent<UpgradeController>();
        MoneyController moneyController = GetComponent<MoneyController>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject tower = GameObject.FindGameObjectWithTag("Base");
        HealthController healthControllerPlayer = player.GetComponent<HealthController>();
        HealthController healthControllerBase = tower.GetComponent<HealthController>();
        save.levels = upgradeController.getLevels();
        save.money = moneyController.GetMoney();
        save.healthPlayer = healthControllerPlayer.GetHealth();
        save.healthBase = healthControllerBase.GetHealth();
        
        
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + name + ".save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log(Application.persistentDataPath);
        Debug.Log("Game Saved");
    }

    public void LoadGame(string name)
    {
        if (File.Exists(Application.persistentDataPath + "/" + name + ".save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + name + ".save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            
            UpgradeController upgradeController = GetComponent<UpgradeController>();
            MoneyController moneyController = GetComponent<MoneyController>();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject tower = GameObject.FindGameObjectWithTag("Base");
            HealthController healthControllerPlayer = player.GetComponent<HealthController>();
            HealthController healthControllerBase = tower.GetComponent<HealthController>();

            moneyController.AddMoney(int.MaxValue);
            upgradeController.UpgradeBaseHp(save.levels[0]);
            upgradeController.UpgradeTurret(0, save.levels[1]);
            upgradeController.UpgradeTurret(1, save.levels[2]);
            upgradeController.UpgradeTurret(2, save.levels[3]);
            upgradeController.UpgradeTurret(3, save.levels[4]);
            upgradeController.UpgradeAttack(save.levels[5]);
            upgradeController.UpgradeHp(save.levels[6]);
            moneyController.RemoveMoney(moneyController.GetMoney() - save.money);
            healthControllerPlayer.SetHealth(save.healthBase);
            healthControllerBase.SetHealth(save.healthPlayer);
            
            Debug.Log(save.levels[0]);
        }
        else
        {
            Debug.Log("No game saved!");
        }
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
    public void DeleteGame(string name)
    {
        if (File.Exists(Application.persistentDataPath + "/" + name + ".save"))
        {
            File.Delete(Application.persistentDataPath + "/" + name + ".save");
            Debug.Log("Game Deleted");
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}