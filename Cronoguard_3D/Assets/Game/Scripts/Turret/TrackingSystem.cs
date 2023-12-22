using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    public bool rotating;
    
    public void Rotate(GameObject target, float speed)
    {
        Vector3 targetDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
               
        Quaternion desiredRotation = Quaternion.Euler(0f, 0f, angle - 90f);
        if (transform.rotation != desiredRotation)
        {
            rotating = true;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, speed * Time.deltaTime);
        }
        else
        {
            rotating = false;
        }
    }
}
