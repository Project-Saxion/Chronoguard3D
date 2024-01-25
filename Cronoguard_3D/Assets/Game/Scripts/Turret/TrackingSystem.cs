using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class TrackingSystem : MonoBehaviour
{
    public bool rotating;
    
    public void Rotate(GameObject target, float speed)
    {
        Vector3 position = target.transform.position;
        Vector3 offset = new Vector3(0, 0.2f, 0);
        Quaternion desiredRotation = Quaternion.LookRotation(position + offset - transform.position);
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