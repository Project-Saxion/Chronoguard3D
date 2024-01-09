using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] public int attackDamage;
    [SerializeField] private int shootForce;

    public void Attack(string _tagToDamage)
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;
            bullet.SetActive(true);
        }
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.damage = attackDamage;
        bulletController.tagToDamage = _tagToDamage;
        bulletController.FireBullet(shootForce);
    }
}
