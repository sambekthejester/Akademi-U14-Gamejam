using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime = 0.25f;

    private Transform CameraTransform;
    private Vector3 velocity;

    private void Awake()
    {
        CameraTransform = transform;
    }

    private void LateUpdate()
    {
        CameraTransform.position = Vector3.SmoothDamp(CameraTransform.position, target.position + offset, ref velocity, smoothTime);
    }
}
