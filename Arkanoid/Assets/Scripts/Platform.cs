using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    void Update()
    {
        float mousePosWorldUnitX = ((Input.mousePosition.x) / Screen.width * 16) - 8;
        
        Vector2 platformPos = new Vector2(0, transform.position.y);

        platformPos.x = Mathf.Clamp(mousePosWorldUnitX, -7.4f, 7.4f);

        transform.position = platformPos;
    }
}