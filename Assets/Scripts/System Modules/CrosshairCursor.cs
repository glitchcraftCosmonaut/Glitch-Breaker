using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    public PlayerInputHandler input;
    // Update is called once per frame
    void Update()
    {
        // Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(input.MouseScreenPos);
        // Debug.Log(mouseCursorPos);
        transform.position = input.MouseScreenPos;
    }
}
