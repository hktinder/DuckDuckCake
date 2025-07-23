using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float offset;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            target.position.z + offset
        );

        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
        transform.position = newPosition;
    }

    private Vector3 velocity = Vector3.zero;
}
