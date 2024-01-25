using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Enemy;
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
    public Animator[] characterAnimators;
    public EnemySpawning enemySpawning;
    
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    
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
    
    Vector3 closestSurfacePoint1;
    Vector3 closestSurfacePoint2;

    private bool hasArrived = false;
    
    private void Start()
    {
        _attackTime = Time.time;
        
        player = GameObject.FindGameObjectWithTag("Player");
        mainTarget = GameObject.FindGameObjectWithTag("Base");
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        enemySpawning = GameObject.Find("Managers").GetComponent<EnemySpawning>();
        
        _targetSize = _mainTargetSize;

        navMeshAgent.speed = movementSpeed;
        navMeshAgent.destination = mainTarget.transform.position;
        _target = mainTarget.transform;

    }

    private void Update()
    {
        ChangeTargetOnRange();
        StopOnAttackRange();
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        foreach (Animator animator in characterAnimators)
        {
            animator.SetFloat("Velocity", navMeshAgent.velocity.magnitude);
        }
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
        if (Vector3.Distance(transform.position, player.transform.position) < targetRange && player.gameObject.activeInHierarchy)
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
        if ((navMeshAgent.pathStatus == NavMeshPathStatus.PathPartial && !navMeshAgent.hasPath) ||
            ((Vector3.Distance(navMeshAgent.destination, navMeshAgent.transform.position) <= navMeshAgent.stoppingDistance) &&
             (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)))
        {
            SetFollowing(false);
            RotateToTarget();
            Attack();
        } else if (Vector3.Distance(transform.position, navMeshAgent.destination)/*GetTrueDistance() */< attackRange)
        {
            SetFollowing(false);
            RotateToTarget();
            Attack();
            //Debug.Log("1 - " + GetTrueDistance());
        }
        else if (!IsFollowing() && GetTrueDistance() > attackRange)
        {
            SetFollowing(true);
            //Debug.Log("2 - " + GetTrueDistance());
        }
    }

    void Attack()
    {
        if (Time.time - _attackTime > attackCooldown)
        {
            onAttack.Invoke();
            _attackTime = Time.time;

            foreach (Animator animator in characterAnimators)
            {
                animator.ResetTrigger("Attack");
                animator.SetTrigger("Attack");
            }
        }
    }

    public void Die()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        foreach (GameObject turret in turrets)
        {
            TurretController turretController = turret.GetComponent<TurretController>();
            turretController.RemoveTargetFromList(gameObject);
        }

        foreach (Animator animator in characterAnimators)
        {
            animator.SetTrigger("Death");
        }

        SetTarget(transform);
        enemySpawning.DestroyEnemy();
//        Destroy(gameObject);
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject == _target.gameObject)
        {
            hasArrived = true;
            SetFollowing(false);
            RotateToTarget();
            Attack();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        hasArrived = false;
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

    float GetTrueDistance()
    {
        // the surface point of this collider that is closer to the position of the other collider
        closestSurfacePoint1 = GetComponentInChildren<Collider>().ClosestPointOnBounds(_target.transform.position);
       
        // the surface point of the other collider that is closer to the position of this collider
        closestSurfacePoint2 = _target.GetComponentInChildren<Collider>().ClosestPointOnBounds(transform.position);
       
        // the distance between the surfaces of the 2 colliders
        float surfaceDistance = Vector3.Distance(closestSurfacePoint1, closestSurfacePoint2);
        return surfaceDistance;
    }
    

}
