using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool AutoPlay { get; set; } = false;
    Ball ball = null;

    private void Awake()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    void Update()
    {
        if (AutoPlay)
        {
            transform.position = new Vector2(ball.transform.position.x, transform.position.y);
        }
        else
        {
            float mousePosWorldUnitX = ((Input.mousePosition.x) / Screen.width * 16) - 8;

            Vector2 platformPos = new Vector2(0, transform.position.y);

            platformPos.x = Mathf.Clamp(mousePosWorldUnitX, -7.4f, 7.4f);

            transform.position = platformPos;
        }
    }
}