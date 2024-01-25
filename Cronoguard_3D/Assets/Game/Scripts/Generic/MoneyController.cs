using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
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
