using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private List<Vector3> points = new List<Vector3>();
    private bool isReturning;
    private Vector3 startingPoint;
    private Vector3 targetPoint;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 1;
        isReturning = false;
        startingPoint = transform.position;
        points.Insert(0, startingPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Count > 0)
        {
            targetPoint = points[counter];

            if (isReturning)
            {
                if (Vector3.Distance(transform.position, targetPoint) < 0.001f)
                {
                    counter--;
                }

                if (counter == -1)
                {
                    isReturning = false;
                    counter = 0;
                }
            }

            else if (!isReturning)
            {
                if (Vector3.Distance(transform.position, targetPoint) < 0.001f)
                {
                    counter++;
                }

                if (counter == points.Count)
                {
                    isReturning = true;
                    counter = points.Count - 1;
                }
            }

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);
        }
    }
}
