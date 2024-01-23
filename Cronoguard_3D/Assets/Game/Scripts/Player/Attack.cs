using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 1;
    public float modifier = 1;
    
    public enum WeaponType { Melee, Bullet, Heavy }

    public WeaponType weaponType;

    private void OnTriggerEnter(Collider collision)
    {
        HealthController healthController = collision.gameObject.GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.DoDamage(Mathf.CeilToInt(damage * modifier));
        }
    }

    public void SetModifier(float amount)
    {
        modifier = amount;
    }

    public float GetModifier()
    {
        return modifier;
    }
}