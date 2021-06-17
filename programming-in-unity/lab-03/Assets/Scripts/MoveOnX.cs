using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnX : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;
    private bool isGoingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        Vector3 move = new Vector3(step, 0, 0);

        if (isGoingRight)
            rb.MovePosition(transform.position + move);
        else
            rb.MovePosition(transform.position - move);

        if (rb.position.x >= 10)
            isGoingRight = false;
        else if (rb.position.x <= 0)
            isGoingRight = true;
    }
}
