using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    private int numHits;
    public static int destructibleBlockNum = 0;

    public int points;

    private SpriteRenderer spriteRenderer;
    private SceneControl sceneControl;
    private Score score;
    private AudioSource audioSource;

    public static bool hit = false;

    void Start()
    {
        sceneControl = FindObjectOfType<SceneControl>();
        score = FindObjectOfType<Score>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        numHits = 0;

        if (transform.CompareTag("Destructible"))
        {
            destructibleBlockNum++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.CompareTag("Destructible"))
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

            Damage();
        }
        else
            hit = true;
    }

    private void Damage()
    {
        numHits++;

        int maxHits = sprites.Length + 1;

        if (numHits >= maxHits)
        {
            destructibleBlockNum--;

            score.addPoints(points);

            sceneControl.DestroyedBlock();

            Destroy(gameObject);
        }
        else
        {
            LoadSprite();
        }
    }

    private void LoadSprite()
    {
        int spriteIndex = numHits - 1;

        if (sprites[spriteIndex])
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }
}
