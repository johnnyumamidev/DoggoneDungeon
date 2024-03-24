using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    CheckpointSystem checkpointSystem;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite spikesUpSprite, spikesDownSprite;
    bool active = true;
    public void Activate(ISwitch _switch) {
        active = !_switch.IsTriggered();
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
            Transform unitTransform = ((MonoBehaviour)unit).transform; 
            if(checkpointSystem == null) {
                checkpointSystem = FindObjectOfType<CheckpointSystem>();
                return;
            }
            checkpointSystem.PlacePlayerAtCheckpoint(unitTransform);
        }
    }
}
