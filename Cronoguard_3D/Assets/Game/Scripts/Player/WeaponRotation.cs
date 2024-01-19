using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class WeaponRotation : MonoBehaviour
{
    private Camera mainCam;
    private float vertical;
    private float horizontal;
    public Vector3 mousePos;
    
    [SerializeField] private LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        GetVertical();
        GetHorizontal();
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();

        if (success)
        {
            var direction = position - transform.position;
            direction.y = 0;

            transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }

    public float GetVertical()
    {
        float angleVer = Vector2.SignedAngle(- transform.up, mousePos);
        

        if (angleVer > 90 || angleVer < -90) {
            angleVer = angleVer > 0 ? 180 - angleVer : -180 - angleVer;
        }
        
        return angleVer;
    }

    public float GetHorizontal()
    {
        float angleHor = Vector2.SignedAngle(transform.right, mousePos);
        
        if (angleHor > 90 || angleHor < -90) {
            angleHor = angleHor > 0 ? 180 - angleHor : -180 - angleHor;
        }

        return angleHor;
    } 
}
