using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Game.Scripts.Generic;
using UnityEngine;

public class SavingGame : MonoBehaviour
{
    // private void Start()
    // {
    //     DeleteGame("testFile");
    //     SaveGame("testFile");
    // }

    public List<string> getSaveGames()
    {
        return new List<string>();
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
            upgradeController.UpgradeTurret(save.levels[1]);
            upgradeController.UpgradeTurretDamage(0, save.levels[2]);
            upgradeController.UpgradeTurretDamage(1, save.levels[3]);
            upgradeController.UpgradeTurretDamage(2, save.levels[4]);
            upgradeController.UpgradeTurretDamage(3, save.levels[5]);
            upgradeController.UpgradeAttack(save.levels[6]);
            upgradeController.UpgradeHP(save.levels[7]);
            moneyController.RemoveMoney(moneyController.GetMoney() - save.money);
            healthControllerPlayer.SetHealth(save.healthBase);
            healthControllerBase.SetHealth(save.healthPlayer);
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

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