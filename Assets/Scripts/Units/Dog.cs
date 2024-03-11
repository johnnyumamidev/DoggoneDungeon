using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dog : MonoBehaviour
{
    void Update() {
        Collider2D playerCheck = Physics2D.OverlapCircle(transform.position, 0.25f);
        if(playerCheck && playerCheck.TryGetComponent(out Player player)) {
            GameStateManager.Instance.TransitionTo("LevelSelect");
        }
    }
}
