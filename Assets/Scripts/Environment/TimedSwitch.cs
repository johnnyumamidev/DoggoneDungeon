using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TimedSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent<bool> onInteract;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] TimeIncrementManager timeIncrementManager;
    bool active = false;
    int ticks;
    public int tickCount = 5;
    void OnEnable() {
        timeIncrementManager.OnTick += Tick;
    }
    void OnDisable() {
        timeIncrementManager.OnTick -= Tick;
    }
    void Update() {
        if(active) {
            spriteRenderer.transform.rotation = Quaternion.Euler(0,0,90);
        }
        else {
            spriteRenderer.transform.rotation = Quaternion.Euler(0,0,0);
        }

        onInteract?.Invoke(active);
    }
    void Tick() {
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
