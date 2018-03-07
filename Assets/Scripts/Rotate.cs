using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 20.0f;


    [SerializeField]
    private float rotationSpeedMin = 50.0f;

    [SerializeField]
    private float rotationSpeedMax = 200.0f;

    [SerializeField]
    private float rotateX = 0.0f;
    [SerializeField]
    private float rotateY = 0.0f;
    [SerializeField]
    private float rotateZ = 0.0f;

    private Vector3 rotationAngle;

    private void Start()
    {
        rotationAngle = new Vector3(rotateX, rotateY, rotateZ);
        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
    }

    private void FixedUpdate()
    {
        transform.Rotate(rotationAngle * rotationSpeed * Time.fixedDeltaTime);
    }
}
