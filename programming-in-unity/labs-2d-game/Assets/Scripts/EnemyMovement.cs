using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform startingPoint;
    [SerializeField] Transform destinationPoint;
    [SerializeField] Transform playerPos;
    [SerializeField] Animator animator;
    [SerializeField] float playerTriggerRadius = 1;

    private bool facingRight = true;
    private bool isGuarding = true;
    private bool isSeeingPlayer = false;
    private CircleCollider2D playerTrigger;
    private bool isGoingToDest = true;
    private Vector2 startingVector;
    private Vector2 destinationVector;

    void Start()
    {
        playerTrigger = GetComponent<CircleCollider2D>();
        startingVector = new Vector2(startingPoint.position.x, transform.position.y);
        destinationVector = new Vector2(destinationPoint.position.x, transform.position.y);
        playerTrigger.radius = playerTriggerRadius;
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Update()
    {
        animator.SetFloat("Speed", speed);
        float step = speed * Time.deltaTime;
        
        if (!isGuarding)
        {
            if (isSeeingPlayer)
            {
                if (!(transform.position.x < startingVector.x || transform.position.x > destinationVector.x))
                {
                    Vector2 playerVector = new Vector2(playerPos.position.x, transform.position.y);

                    if (facingRight && playerVector.x < transform.position.x)
                    {
                        Flip();
                        facingRight = false;
                    }

                    else if (!facingRight && playerVector.x > transform.position.x)
                    {
                        Flip();
                        facingRight = true;
                    }

                    transform.position = Vector2.MoveTowards(transform.position, playerVector, step);
                }
            }
        }

        else if (isGuarding)
        {
            if (isGoingToDest)
            {
                if (!facingRight)
                {
                    Flip();
                    facingRight = true;
                }

                transform.position = Vector2.MoveTowards(transform.position, destinationVector, step);

                if (Mathf.Abs(transform.position.x - destinationVector.x) <= 0.1)
                {
                    isGoingToDest = false;
                    facingRight = false;
                    Flip();
                }

            }

            else if (!isGoingToDest)
            {
                if (facingRight)
                {
                    Flip();
                    facingRight = false;
                }

                transform.position = Vector2.MoveTowards(transform.position, startingVector, step);

                if (Mathf.Abs(transform.position.x - startingVector.x) <= 0.1)
                {
                    isGoingToDest = true;
                    facingRight = true;
                    Flip();
                }
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isSeeingPlayer = true;
            isGuarding = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isSeeingPlayer = false;
            isGuarding = true;
        }
    }

}
