using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    public float zOffset;
    public float yOffset;
    public float smoothTime;
    public float cameraRotationX;

    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        FollowPlayer(zOffset, yOffset);
        RotateCamera();
    }

    void FollowPlayer(float _zOffset, float _yOffset)
    {
        Vector3 targetPosition = player.transform.position - new Vector3(0, 0, _zOffset) + (player.transform.up * _yOffset);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    void RotateCamera()
    {
        transform.rotation = Quaternion.Euler(cameraRotationX, player.transform.rotation.y, 0);
    }
    
}
