using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingRoom : MonoBehaviour
{
    public float scrollSpeed = 2;
    public Vector2 scrollDirection;
    bool active = false;
    public void StartScroll() {
        active = true;
    }

    void Update() {
        if(active)
            Scroll();
    }

    private void Scroll()
    {
        transform.position += (Vector3)scrollDirection * scrollSpeed * Time.deltaTime;
    }
}
