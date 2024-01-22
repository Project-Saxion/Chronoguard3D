using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject[] hitEnemies;
    public int damage = 1;
    public float modifier = 1;
    
    public enum WeaponType { Melee, Bullet, Heavy }

    public WeaponType weaponType;

    private void OnTriggerEnter(Collider collision)
    {
        HealthController healthController = collision.transform.root.GetComponent<HealthController>();
        if (healthController != null)
        {
            hitEnemies.Append(collision.gameObject);
            healthController.DoDamage(Mathf.CeilToInt(damage * modifier));
        }
        Debug.Log(hitEnemies);
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