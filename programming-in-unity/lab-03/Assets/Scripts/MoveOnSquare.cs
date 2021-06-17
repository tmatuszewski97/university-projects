using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MoveOnSquare : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;
    bool justSpawned = true;
    private bool isGoingRight = true;
    private bool isGoingTop = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetDirectionAndRotate()
    {
        int shouldRotate = 0;
        
        if (rb.position.x <= 0)
        {
            isGoingRight = true;
            shouldRotate++;
        }
        else if (rb.position.x >= 10)
        {
            isGoingRight = false;
            shouldRotate++;
        }

        if (rb.position.z <= 0)
        {
            isGoingTop = true;
            shouldRotate++;
        }
        else if (rb.position.z >= 10)
        {
            isGoingTop = false;
            shouldRotate++;
        }

        if (shouldRotate == 2)
            rb.transform.Rotate(0, 90, 0, Space.Self);
    }

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        Vector3 moveHorizontal = new Vector3(step, 0, 0);
        Vector3 moveVertical = new Vector3(0, 0, step);

        if (!justSpawned)
            SetDirectionAndRotate();
        else
            justSpawned = false;

        if (isGoingRight && isGoingTop)
            rb.MovePosition(transform.position + moveHorizontal);
        else if (!isGoingRight && isGoingTop)
            rb.MovePosition(transform.position + moveVertical);
        else if (!isGoingRight && !isGoingTop)
            rb.MovePosition(transform.position - moveHorizontal);
        else
            rb.MovePosition(transform.position - moveVertical);
    }
}
