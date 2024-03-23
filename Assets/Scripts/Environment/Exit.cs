using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour, IInteractable
{
    [SerializeField] Lock[] locks;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite closedSprite, openSprite;
    bool unlocked = false;
    [SerializeField] Transform switchesParent;
    List<ISwitch> switches = new List<ISwitch>();
    // List<Lock> unlockedLocks = new List<Lock>();
    public void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        // foreach(Lock _lock in locks) {
        //     if(_lock.unlocked && !unlockedLocks.Contains(_lock))
        //         unlockedLocks.Add(_lock);
        // }
        // if(unlockedLocks.Count == locks.Length)
        //     Debug.Log("Floor cleared, go to next floor!");
        // else {
        //     Debug.Log("There are still locks remaining");
        // }
    }
    void Start() {
        foreach(Transform child in switchesParent) {
            if(child.TryGetComponent(out ISwitch _switch))
                switches.Add(_switch);
        }
    }
    void Update()
    {
        spriteRenderer.sprite = openSprite;
        if(!unlocked) {
            spriteRenderer.sprite = closedSprite;
        }
    }
    public void ControlDoor(ISwitch _switch) {
        //if all switches are enabled, unlock door
        List<ISwitch> activeSwitches = new();
        
        for(int i = 0; i < switches.Count; i++) {
            if(switches[i].IsTriggered() && !activeSwitches.Contains(switches[i])) {
                activeSwitches.Add(switches[i]);
            }
            else {
                activeSwitches.Remove(switches[i]);
            }

            if(activeSwitches.Count == switches.Count)
                unlocked = true;
            else {
                unlocked = false;
            }
        }
    }
}
