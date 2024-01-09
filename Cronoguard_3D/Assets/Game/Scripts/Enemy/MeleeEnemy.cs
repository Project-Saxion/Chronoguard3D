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
    
    
    
    private void Start()
    {
        _basicEnemyController = GetComponent<BasicEnemyController>();
    }

    public void MeleeAttack()
    {
        _target = _basicEnemyController.GetTarget().gameObject;
        _targetHealthController = _target.GetComponent<HealthController>();
        if (_targetHealthController != null)
        {
            //_targetHealthController.doDamage(attackDamage);
        }
        Debug.Log("Attacked " + _target.gameObject.name);
        //play animation
    }
}
