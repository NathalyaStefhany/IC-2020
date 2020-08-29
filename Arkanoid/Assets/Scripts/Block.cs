﻿using System.Collections;
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

    SceneControl sceneControl;
    Score score;
    AudioSource audioSource;

    void Start()
    {
        numHits = 0;

        sceneControl = FindObjectOfType<SceneControl>();
        score = FindObjectOfType<Score>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

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
