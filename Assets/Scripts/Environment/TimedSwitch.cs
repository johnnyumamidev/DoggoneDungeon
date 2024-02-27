using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TimedSwitch : MonoBehaviour, IInteractable, ITicker
{
    [SerializeField] UnityEvent<bool> onInteracted;
    [SerializeField] UnityEvent onTimeElapsed;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool active = false;
    int ticks;
    public int tickCount = 5;
    float angle;
    void Update() {
        spriteRenderer.transform.rotation = Quaternion.Euler(0,0,angle);
        onInteracted?.Invoke(active);
    }
    public void Tick() {
        if(!active) return;

        angle -= 90/(tickCount+1);
        ticks++;
        if(ticks > tickCount) {
            ticks = 0;
            active = false;
            onTimeElapsed?.Invoke();
        }
    }

    public void Interact()
    {
        active = true;
        angle = 90;
    }

    public void Cancel() {
        active = false;
        onInteracted?.Invoke(active);
    }
}
