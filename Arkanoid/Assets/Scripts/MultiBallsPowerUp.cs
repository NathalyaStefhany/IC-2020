using Castle.Components.DictionaryAdapter.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBallsPowerUp : MonoBehaviour, IPowerUp
{
    private AudioSource audioSource;

    private IPowerUp powerUp;

    [SerializeField]
    Ball ball;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ExecutePowerUp(GameObject target)
    {
        Instantiate(ball, target.transform.position, Quaternion.identity);
        Instantiate(ball, target.transform.position, Quaternion.identity);

        Ball[] balls = GameObject.FindObjectsOfType<Ball>();

        foreach (Ball ball in balls)
        {
            if (ball != target.gameObject.GetComponent<Ball>())
                ball.ThrowBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

        Destroy(gameObject);

        //powerUp.ExecutePowerUp(collision.gameObject);

        ExecutePowerUp(collision.gameObject);
    }

    public void setPowerUp(IPowerUp powerUp)
    {
        this.powerUp = powerUp;
    }
}
