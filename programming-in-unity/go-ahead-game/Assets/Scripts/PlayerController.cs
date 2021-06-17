using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 180f;
    [SerializeField]
    private Rigidbody rb = null;
    [SerializeField]
    private float minCameraDistance = 0.75f;

    private Vector2 lastMousePosition;

    void Update()
    {
        // Możemy się poruszać dopiero po rozpoczęciu gry
        if (GameManager.singleton.GameStarted && !GameManager.singleton.GamePaused)
        {
            Vector2 distance = Vector2.zero;

            if (Input.GetMouseButton(0))
            {
                Vector2 actualMousePosition = Input.mousePosition;

                if (lastMousePosition == Vector2.zero)
                    lastMousePosition = actualMousePosition;

                distance = actualMousePosition - lastMousePosition;
                lastMousePosition = actualMousePosition;
                Vector3 force = new Vector3(distance.x, 0, distance.y) * speed;
                rb.AddForce(force);
            }

            else
                lastMousePosition = Vector2.zero;
        }
    }

    // Player delikatnie porusza się naprzód nawet gdy nic nie robimy
    private void FixedUpdate()
    {
        if (GameManager.singleton.GameStarted && !GameManager.singleton.GamePaused)
        {
            rb.MovePosition(transform.position + Vector3.forward * 5 * Time.fixedDeltaTime);
        }
    }

    private void LateUpdate()
    {
        if (GameManager.singleton.GameStarted && !GameManager.singleton.GamePaused)
        {
            Vector3 position = transform.position;

            // Jeśli gracz wypadł poza tor - przegrana
            if (transform.position.y <= -0.1)
            {
                GameManager.singleton.EndGame(false);
            }

            // Gracz nie może wyskoczyć poza początek planszy
            if (transform.position.z < Camera.main.transform.position.z + minCameraDistance)
            {
                position.z = Camera.main.transform.position.z + minCameraDistance;
            }

            transform.position = position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.singleton.GameStarted && !GameManager.singleton.GamePaused)
        {
            GameManager.singleton.NumberOfCollisions++;

            // Jeśli gracz uderzył w przeszkodę - przegrana
            if (collision.gameObject.tag == "Enemy")
                GameManager.singleton.EndGame(false);

            // Jeśli trafiamy na diament - podnosimy go i zwiekszamy wynik
            if (collision.gameObject.tag == "Diamond")
            {
                GameManager.singleton.Score += 10;
                Destroy(collision.gameObject);
            }
        }
    }
}
