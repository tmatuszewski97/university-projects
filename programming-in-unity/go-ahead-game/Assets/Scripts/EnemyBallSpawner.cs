using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyBall = null;
    [SerializeField] private float delay = 0.25f;
    [SerializeField] float minimumX = -5;
    [SerializeField] float maximumX = 5;

    private float timer;
    private Vector3 ballPosition;

    void Start()
    {
        timer = delay;
    }

    void Update()
    {
        if (GameManager.singleton.GameStarted && !GameManager.singleton.GamePaused)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                ballPosition = new Vector3(Random.Range(minimumX, maximumX), transform.position.y, transform.position.z);
                Instantiate(enemyBall, ballPosition, Quaternion.identity);
                timer = delay;
            }
        }
    }
}
