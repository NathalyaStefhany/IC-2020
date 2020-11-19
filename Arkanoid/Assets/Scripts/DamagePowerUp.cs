using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    [SerializeField]
    IDamage damage;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        ball.setDamage(Instantiate(damage, transform));

        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        
        Destroy(gameObject);        
    }
}
