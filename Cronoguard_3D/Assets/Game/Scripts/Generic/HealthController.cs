using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int health;
    private int _maxHealth;

    [SerializeField] private int healRate;
    [SerializeField] private int healTimer;

    [SerializeField] private bool autoHeal = true;
    
    public UnityEvent death;

    private float _startTime;
    private float _elapsedTime;

    private float _startHealTime;
    private float _elapsedHealTime;

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetMaxHealth(int newHealth)
    {
        _maxHealth = newHealth;
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public void DoDamage(int damage)
    {
        _startTime = Time.time;
        health -= damage;
        if (health < 0)
        {
            health = 0;
            death.Invoke();
        }
    }

    public void Heal(int healAmount)
    {
        if (health + healAmount <= _maxHealth)
        {
            health += healAmount;
        }
        else
        {
            health = _maxHealth;
        }
    }

    public void AutomaticHeal(int healRate)
    {
        _elapsedTime = Time.time - _startTime;
        if (_elapsedTime >= healTimer)
        {
            if (_startHealTime == 0)
            {
                _startHealTime = Time.time;
            }

            _elapsedHealTime = Time.time - _startHealTime;
            if (_elapsedHealTime >= 1)
            {
                _startHealTime = Time.time;
                Heal(healRate);
            }
        }
    }
    
    
    void Awake()
    {
        _maxHealth = health;
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (autoHeal)
        {
            AutomaticHeal(healRate);
        }
    }
}
