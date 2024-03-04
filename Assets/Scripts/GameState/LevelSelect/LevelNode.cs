using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelNode : MonoBehaviour
{
    public event Action<LevelNode, bool> OnPlayerDetected;
    [SerializeField] bool unlocked = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color lockedColor, unlockedColor;
    void Update()
    {
        if(DetectPlayer())
            OnPlayerDetected?.Invoke(this, unlocked);

        if(unlocked) {
            spriteRenderer.color = unlockedColor;
        }
        else {
            spriteRenderer.color = lockedColor;
        }
    }

    Player DetectPlayer()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.25f);
        if (collider)
        {
            Player player = collider.GetComponent<Player>();
            return player;
        }
        return null;
    }

    public void UnlockLevel() {
        unlocked = true;
    }
}
