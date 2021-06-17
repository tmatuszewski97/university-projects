using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    [SerializeField] private bool moveForward = true;
    [SerializeField] private float speed = 5;

    private void FixedUpdate()
    {
        if (GameManager.singleton.GameStarted && !GameManager.singleton.GamePaused)
        {
            if (moveForward)
                transform.position = transform.position + Vector3.forward * 5 * Time.fixedDeltaTime;
            else if (!moveForward)
                transform.position = transform.position + -Vector3.forward * speed * Time.fixedDeltaTime;
        }
    }
}
