using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject target;

    [SerializeField] private int range = 7;

    [SerializeField] private int fireRate = 1;

    [SerializeField] private float rotationSpeed = 100f;

    private List<GameObject> allTargets = new List<GameObject>();

    private ShootingSystem _shootingSystem;

    private TrackingSystem _trackingSystem;

    private bool _canShoot = true;

    private bool _inRange = true;
    // Start is called before the first frame update
    void Start()
    {
        FindTargets();
        _shootingSystem = GetComponent<ShootingSystem>();
        _trackingSystem = GetComponent<TrackingSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target.IsUnityNull())
        {
            _inRange = Vector3.Distance(transform.position, target.transform.position) < range;
            if (_inRange)
            {
                _trackingSystem.Rotate(target, rotationSpeed);
                if (_canShoot && !_trackingSystem.rotating)
                {
                    _canShoot = false;
                    // Wait till timer is done
                    StartCoroutine(nameof(AllowToShoot));
                    _shootingSystem.Attack("Enemy");
                }
            }
            else
            {
                target = FindNearestTarget();
            }
        }
        else
        {
            target = FindNearestTarget();
        }
    }
    private IEnumerator AllowToShoot ()
    {
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }
    
    private GameObject FindNearestTarget()
    {
        if (allTargets.Count > 0)
        {
            target = allTargets[0]; 
            foreach (GameObject tmpTarget in allTargets) 
            { 
                if (
                    Vector3.Distance(transform.position, tmpTarget.transform.position) < Vector3.Distance(transform.position, target.transform.position)
                )
                {
                    target = tmpTarget;
                }
            } 
            return target;  
        }
        return null;

    }
    
    public void FindTargets()
    {
        allTargets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }
    public void RemoveTargetFromList(GameObject removeAbleTarget)
    {
        if (allTargets.Contains(removeAbleTarget))
        {
            allTargets.Remove(removeAbleTarget);
        }
    }
    
    public void SetFireRate(int amount)
    {
        fireRate = amount;
    }

    public int GetFireRate()
    {
        return fireRate;
    }
}
