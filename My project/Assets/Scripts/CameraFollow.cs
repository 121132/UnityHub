using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothing = 2;

    public void LateUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smoothing);
        }
    }
}
