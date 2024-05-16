using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.1f;

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 finallPosition = Vector3.Lerp(transform.position, target.position, smoothSpeed); // Сглаживание движения камеры
            transform.position = new Vector3(finallPosition.x, finallPosition.y, transform.position.z); // Обновление позиции камеры
        }
    }
}
