using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    //values
    [SerializeField] private int attackDamage;
    [SerializeField] private int shootForce;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    
    //references and stuff
    private BasicEnemyController _basicEnemyController;
    private GameObject _target;
    private HealthController _targetHealthController;
    private ShootingSystem shootingSystem;
    
    private void Start()
    {
        _basicEnemyController = GetComponent<BasicEnemyController>();
        shootingSystem = GetComponent<ShootingSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootingSystem.Attack("Player");
        }
    }

    public void Attack()
    {
        GameObject _bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (_bullet != null)
        {
            _bullet.transform.position = shootPoint.position;
            _bullet.transform.rotation = shootPoint.rotation;
            _bullet.SetActive(true);
        }
        Rigidbody bulletRB = _bullet.GetComponent<Rigidbody>();
        BulletController bulletController = _bullet.GetComponent<BulletController>();
        bulletRB.AddForce(transform.forward * shootForce);
        bulletController.damage = attackDamage;
    }

}
