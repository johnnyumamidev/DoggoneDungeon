using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour, IInteractable
{
    DungeonMapManager dungeonMapManager;
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
        if(unlocked) {
            dungeonMapManager.TravelBetweenFloors(1);
            Debug.Log("door open, proceed to next floor");
        }
        else {
            Debug.Log("door locked");
        }
    }
    void Awake() {
        dungeonMapManager = FindObjectOfType<DungeonMapManager>();
    }
    void Start() {
        if(switchesParent == null) 
            return;

        foreach(Transform child in switchesParent) {
            if(child.TryGetComponent(out ISwitch _switch))
                switches.Add(_switch);
        }
    }
    void Update()
    {
        spriteRenderer.sprite = closedSprite;
        if(unlocked) {
            spriteRenderer.sprite = openSprite;
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
