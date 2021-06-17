using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    [SerializeField] float minRotationSpeed = 60;
    [SerializeField] float maxRotationSpeed = 100;
     
    private int rotationDirection;
    private float rotationSpeed;

    void Start()
    {
        rotationDirection = Random.Range(0, 2);
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    void Update()
    {
        switch (rotationDirection)
        {
            case 0:
                transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
                break;
            case 1:
                transform.Rotate(0, -Time.deltaTime * rotationSpeed, 0);
                break;
        }
    }
}
