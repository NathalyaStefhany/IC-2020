using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Block : MonoBehaviour, Observable
{
    [SerializeField]
    public Sprite[] sprites;

    private int numHits;  
    public static int destructibleBlockNum = 0;

    public int points;

    private SpriteRenderer spriteRenderer;
    private SceneControl sceneControl;
    private Score score;
    private AudioSource audioSource;

    public static bool hit = false;

    List<Observer> observers;

    void Awake()
    {
        observers = new List<Observer>();

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
        if (transform.CompareTag("Indestructible"))
            hit = true;
    }
   
    public void LoadSprite()
    {
        int spriteIndex = numHits - 1;

        if (sprites[spriteIndex])
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    public void DestroyBlock()
    {
        Notify(this);

        Destroy(this.gameObject);
    }

    public void RegisterObserver(Observer obs)
    {
        observers.Add(obs);
    }

    public void Notify(object observable)
    {
        foreach(var observer in observers)
        {
            observer.update(this);
        }
    }

    public void SetNumHits()
    {
        numHits++;
    }

    public int GetNumHits()
    {
        return numHits;
    }
}
