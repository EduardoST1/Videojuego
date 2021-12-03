using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform objetivo;

    [SerializeField] Vector3 offset;
    [Range(1, 10)]

    [SerializeField] float smoothMovement = 2f;

    private void FixedUpdate()
    {
        SeguirObjetivo();
    }

    void SeguirObjetivo()
    {
        Vector3 target = objetivo.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, target, smoothMovement * Time.deltaTime);

        transform.position = smoothPosition;
    }
}
