<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private int attackDamage;
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
=======
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class ShootingSystem : MonoBehaviour
// {
//     [SerializeField] private int shootForce;
//     [SerializeField] private GameObject bullet;
//     [SerializeField] private Transform shootPoint;
//
//     public void Shoot(int attackDamage)
//     {
//         GameObject _bullet = Instantiate(bullet, shootPoint.position, transform.rotation);
//         Rigidbody2D bulletRB = _bullet.GetComponent<Rigidbody2D>();
//         BulletController bulletController = _bullet.GetComponent<BulletController>();
//         bulletRB.AddForce(transform.up * shootForce);
//         bulletController.damage = attackDamage;
//
//     }
// }
>>>>>>> Stashed changes
