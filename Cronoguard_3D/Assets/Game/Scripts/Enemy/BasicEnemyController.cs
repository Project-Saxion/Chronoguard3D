using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.AI;

public class BasicEnemyController : MonoBehaviour
{
    //references

    public GameObject player;
    public GameObject mainTarget;
    
    private NavMeshAgent navMeshAgent;
    
    //values
    private Transform _target;

    [SerializeField] public float movementSpeed;
    [SerializeField] public float targetRange;
    [SerializeField] public float attackRange;
    [SerializeField] public int attackCooldown;

    public UnityEvent onAttack; 
    private float _attackTime;

    private float _mainTargetSize;
    private float _playerSize;
    private float _targetSize;
    
    private void Start()
    {
        _attackTime = Time.time;
        
        player = GameObject.FindGameObjectWithTag("Player");
        mainTarget = GameObject.FindGameObjectWithTag("Base");
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        _targetSize = _mainTargetSize;

        navMeshAgent.speed = movementSpeed;
        navMeshAgent.destination = mainTarget.transform.position;
        _target = mainTarget.transform;

    }

    private void Update()
    {
        ChangeTargetOnRange();
        StopOnAttackRange();
    }

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
        if (IsFollowing())
        {
            navMeshAgent.destination = _target.transform.position;
        }
    }

    public Transform GetTarget()
    {
        return _target;
    }

    void SetFollowing(bool shouldFollow)
    {
        if (shouldFollow)
        {
            navMeshAgent.destination = _target.position;
        }
        else
        {
            navMeshAgent.destination = transform.position;
        }
    }

    bool IsFollowing()
    {
        if (navMeshAgent.destination == transform.position)
        {
            return false;
        }
        return true;
    }

    void ChangeTargetOnRange()
    {
        
        if (Vector3.Distance(transform.position, player.transform.position) < targetRange /*&& _target.gameObject != player*/ && player.gameObject.activeInHierarchy)
        {
            SetTarget(player.transform);
            _targetSize = _playerSize;
        }
        else
        {
            if (_target.gameObject != mainTarget)
            {
                SetTarget(mainTarget.transform);
                _targetSize = _mainTargetSize;
            }
        }
    }

    void StopOnAttackRange()
    {
        if (Vector3.Distance(transform.position, _target.position) < attackRange)
        {
            SetFollowing(false);
            Debug.Log("1");
            RotateToTarget();
            Attack();
        }
        else if (!IsFollowing())
        {
            Debug.Log("2");
            SetFollowing(true);
        }
    }

    void Attack()
    {
        if (Time.time - _attackTime > attackCooldown)
        {
            onAttack.Invoke();
            _attackTime = Time.time;
        }
    }

    public void Die()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        foreach (GameObject turret in turrets)
        {
            TurretController turretController = turret.GetComponent<TurretController>();
//            turretController.removeTargetFromList(gameObject);
        }

        Destroy(gameObject);
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject == _target.gameObject)
        {
            Attack();
        }
    }

    public void DropMoney(int amount)
    {
//        MoneyManager.Instance.addMoney(amount);
    }

    void RotateToTarget()
    {
        Vector3 lookPos = _target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10);
    }
}
