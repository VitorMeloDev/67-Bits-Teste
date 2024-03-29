using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 pos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, pos, smoothSpeed);
        transform.position = smoothedPos;
        transform.LookAt(target);
    }
}
