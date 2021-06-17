using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class DoorMechanism : MonoBehaviour
{
    [SerializeField]
    public GameObject doors;
    [SerializeField]
    public float doorsSpeed = 2f;
    private bool doorsGoingRight;
    private bool doorsShouldMove;
    private float closedPosition;
    private float openPosition;

    // Start is called before the first frame update
    void Start()
    {
        closedPosition = doors.transform.position.x;
        openPosition = -3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorsShouldMove)
        {
            if (doorsGoingRight && doors.transform.position.x <= openPosition)
            {
                Vector3 move = transform.right * doorsSpeed * Time.deltaTime;
                doors.transform.Translate(move);
            }

            else if (!doorsGoingRight && doors.transform.position.x >= closedPosition)
            {
                Vector3 move = -transform.right * doorsSpeed * Time.deltaTime;
                doors.transform.Translate(move);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Drzwi otwierają się");
            doorsGoingRight = true;
            doorsShouldMove = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Drzwi zamykają się");
            doorsGoingRight = false;
        }
    }
}
