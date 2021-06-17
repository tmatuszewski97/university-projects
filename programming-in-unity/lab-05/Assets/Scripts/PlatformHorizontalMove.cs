using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontalMove : MonoBehaviour
{
    [SerializeField]
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    [SerializeField]
    public float distance = 13.0f;
    private bool isGoingRight = true;
    private bool isGoingLeft = false;
    private float basicPosition;
    private float endPosition;

    void Start()
    {
        endPosition = transform.position.x + distance;
        basicPosition = transform.position.x;
    }

    void Update()
    {
        if (isGoingRight && transform.position.x >= endPosition)
        {
            isRunning = false;
        }
        else if (isGoingLeft && transform.position.x <= basicPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            other.transform.SetParent(transform);
            //other.gameObject.transform.parent = transform;

            if (transform.position.x >= endPosition)
            {
                isGoingLeft = true;
                isGoingRight = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.x <= basicPosition)
            {
                isGoingRight = true;
                isGoingLeft = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            //other.gameObject.transform.parent = null;
            other.transform.SetParent(null);
        }

    }
}
