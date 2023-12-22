using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class TrackingSystem : MonoBehaviour
{
    public bool rotating;
    
    public void Rotate(GameObject target, float speed)
    {
        Quaternion desiredRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        if (transform.rotation != desiredRotation)
        {
            rotating = true;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, speed);
        }
        else
        {
            rotating = false;
        }
    }
}