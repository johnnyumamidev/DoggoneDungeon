using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TimedSwitch : MonoBehaviour, IInteractable, ITicker, ISwitch
{
    [SerializeField] UnityEvent<ISwitch> onInteracted;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool active = false;
    int ticks;
    public int tickCount = 5;
    float angle;
    void Update() {
        spriteRenderer.transform.rotation = Quaternion.Euler(0,0,angle);
    }
    public void Tick() {
        if(!active) return;

        angle -= 90/(tickCount+1);
        ticks++;
        if(ticks > tickCount) {
            ticks = 0;
            active = false;
            onInteracted?.Invoke(this);
        }
    }

    public void Interact()
    {
        active = true;
        onInteracted?.Invoke(this);
        angle = 90;
    }

    public void Cancel() {
        active = false;
        onInteracted?.Invoke(this);
    }

    public bool IsTriggered()
    {
        return active;
    }
}
