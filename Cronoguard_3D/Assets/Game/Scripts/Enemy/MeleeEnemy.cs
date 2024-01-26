using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    //values
    [SerializeField] private int attackDamage;
    
    //references and stuff
    private BasicEnemyController _basicEnemyController;
    private GameObject _target;
    private HealthController _targetHealthController;
    private AudioSource audioSource;
    
    
    
    private void Start()
    {
        _basicEnemyController = GetComponent<BasicEnemyController>();
        audioSource = GetComponent<AudioSource>();
    }

    public void MeleeAttack()
    {
        _target = _basicEnemyController.GetTarget().gameObject;
        _targetHealthController = _target.GetComponent<HealthController>();
        audioSource.Play();
        if (_targetHealthController != null)
        {
            _targetHealthController.DoDamage(attackDamage);
        }
        Debug.Log("Attacked " + _target.gameObject.name);
    }
}
