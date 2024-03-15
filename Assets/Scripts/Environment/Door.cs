using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool open = false;
    Collider2D doorCollider;
    [SerializeField] SpriteRenderer spriteRenderer;
    void Awake() {
        doorCollider = GetComponent<Collider2D>();
    }
    public void ControlDoors(bool b) {
        open = b;
        doorCollider.enabled = !b;
        spriteRenderer.enabled = !b;
    }
}
