using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 1;
    public float modifier = 1;
    
    public enum WeaponType { Melee, Bullet, Heavy }

    public WeaponType weaponType;

    private void OnTriggerEnter(Collider collision)
    {
        HealthController healthController = collision.transform.parent.GetComponent<HealthController>();
        if (healthController != null)
        {
            //healthController.doDamage(Mathf.CeilToInt(damage * modifier));

            if (weaponType == WeaponType.Bullet)
            {
                Destroy(gameObject);
            }
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