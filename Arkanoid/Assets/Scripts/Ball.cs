using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Platform platform;
    private Vector3 platformBallDis;
    private Rigidbody2D rb2d;
    private bool gameStarted = false;

    private AudioSource audioSource;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        platform = FindObjectOfType<Platform>();

        platformBallDis = transform.position - platform.transform.position;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameStarted)
        {
            transform.position = platform.transform.position + platformBallDis;

            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = new Vector2(2f, 10f);
                gameStarted = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Destructible") && gameStarted)
        {
            Vector2 velocityAdjustment = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            rb2d.velocity += velocityAdjustment;

            audioSource.Play();
        }
    }
}
