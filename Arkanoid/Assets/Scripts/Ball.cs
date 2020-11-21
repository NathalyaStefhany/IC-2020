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

    [SerializeField]
    private Damage damage;

    void Awake()
    {
        damage = Instantiate(damage, transform);
    }

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

            Damage normalDamage = GameObject.FindObjectOfType<NormalDamage>();
   
            setDamage(normalDamage);

            if (Input.GetMouseButtonDown(0)) 
                ThrowBall();
        }
    }

    public void ThrowBall()
    {
        rb2d.velocity = new Vector2(2f, 10f);
        gameStarted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Destructible") && gameStarted)
        {
            Vector2 velocityAdjustment = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            rb2d.velocity += velocityAdjustment;

            audioSource.Play();
        }
        else if (collision.gameObject.CompareTag("Destructible"))
        {
            AudioSource audioBlock = collision.gameObject.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audioBlock.clip, transform.position);
            
            damage.ExecuteDamage(collision.gameObject);
        }
    }

    public void setGameStarted(bool gameStarted)
    {
        this.gameStarted = gameStarted;
    }

    public void setDamage(Damage damage)
    {
        this.damage = damage;
    }
}
