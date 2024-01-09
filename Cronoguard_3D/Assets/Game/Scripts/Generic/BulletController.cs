using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody rb;
    public int damage;
    public string tagToDamage;
    public int destroyTimer; 
    

    public void FireBullet(int _shootForce)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.forward * _shootForce);
        StartCoroutine(DestroyAfterTimer(destroyTimer));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToDamage))
        {
            HealthController targetHealthController = other.gameObject.GetComponent<HealthController>();
            //targetHealthController.doDamage(damage);
            gameObject.SetActive(false);
        }
        if (!other.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }
    }
    
    
    IEnumerator DestroyAfterTimer(int destroyTimer)
    {
        yield return new WaitForSeconds(destroyTimer);
        gameObject.SetActive(false);
    }
}
