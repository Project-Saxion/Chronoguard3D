using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    private static MoneyController _instance;

    public static MoneyController Instance
    {
        get
        {
            if (_instance is null)
            {
                Debug.LogError("MoneyController is null");
            }
            return _instance;
        }
    }
    
    private void Awake()
    {
        _instance = this;
    }
    
    [SerializeField] private int money;
    [SerializeField] private GameObject UIManager;

    public int GetMoney()
    {
        return money;
    }

    public void AddMoney(int moneyAmount)
    {
        money += moneyAmount;
        UIManager.GetComponent<UIController>().checkMoney();
    }

    public void RemoveMoney(int moneyAmount)
    {
        money -= moneyAmount;
        UIManager.GetComponent<UIController>().checkMoney();
    }
}
