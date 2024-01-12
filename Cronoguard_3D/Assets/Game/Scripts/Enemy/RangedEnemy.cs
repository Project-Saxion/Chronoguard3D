using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{

    //values
    [SerializeField] private String[] tagsToDamage;
    
    //references and stuff
    private ShootingSystem shootingSystem;

    
    private void Start()
    {
        shootingSystem = GetComponent<ShootingSystem>();
    }

    public void Attack()
    {
        shootingSystem.Attack(tagsToDamage);
    }

}
