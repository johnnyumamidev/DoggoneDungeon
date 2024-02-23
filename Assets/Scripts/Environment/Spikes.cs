using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite spikesUpSprite, spikesDownSprite;
    bool active = true;
    public void Activate(bool b) {
        active = !b;
        if(active) {
            spriteRenderer.sprite = spikesUpSprite;
        }
        else {
            spriteRenderer.sprite = spikesDownSprite;
        }
    }

    void Update() {
        DetectUnits();
    }
    void DetectUnits() {
        if(!active) return;

        Collider2D col = Physics2D.OverlapCircle(transform.position, 0.25f);
        if(col && col.TryGetComponent(out IUnit unit)) 
        {
            //game over
            Debug.Log("hit " + ((MonoBehaviour)unit).name);
        }
    }
}
