using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private int money;

    public int GetMoney()
    {
        return money;
    }

    public void AddMoney(int moneyAmount)
    {
        money += moneyAmount;
    }

    public void RemoveMoney(int moneyAmount)
    {
        money -= moneyAmount;
    }
}
