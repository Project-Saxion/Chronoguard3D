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
    private AudioSource audioSource;
    
    private void Start()
    {
        shootingSystem = GetComponent<ShootingSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        shootingSystem.Attack(tagsToDamage);
        audioSource.Play();
    }

}
