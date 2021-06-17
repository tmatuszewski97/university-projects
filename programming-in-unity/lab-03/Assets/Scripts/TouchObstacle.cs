using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObstacle : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
            Debug.Log("Uderzyłeś w przeszkodę");
    }
}
