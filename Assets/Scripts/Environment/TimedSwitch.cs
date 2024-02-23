using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TimedSwitch : MonoBehaviour, IInteractable, ITicker
{
    [SerializeField] UnityEvent<bool> onInteracted;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool active = false;
    int ticks;
    public int tickCount = 5;
    void Update() {
        if(active) {
            spriteRenderer.transform.rotation = Quaternion.Euler(0,0,90);
        }
        else {
            spriteRenderer.transform.rotation = Quaternion.Euler(0,0,0);
        }

        onInteracted?.Invoke(active);
    }
    public void Tick() {
        if(!active) return;

        ticks++;
        if(ticks > tickCount) {
            ticks = 0;
            active = false;
        }
    }

    public void Interact()
    {
        active = true;
    }

    public void Cancel() {
        active = false;
    }
}
