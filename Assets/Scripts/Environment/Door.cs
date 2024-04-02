using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] List<ISwitch> switches = new List<ISwitch>();
    public bool reverse = false;
    bool closed = true;
    Collider2D doorCollider;
    [SerializeField] SpriteRenderer spriteRenderer;
    void Awake() {
        doorCollider = GetComponent<Collider2D>();
    }

    void Update() {
        doorCollider.enabled = closed;
        spriteRenderer.enabled = closed;
    }
    public void ControlDoors(ISwitch _switch) {
        if(!switches.Contains(_switch)) {
            switches.Add(_switch);
        }

        for(int i = 0; i < switches.Count; i++) {
            if(switches[i].IsTriggered()) {
                closed = false;
                if(reverse)
                    closed = true;
                break;
            }
            else {
                closed = true;
                if(reverse)
                    closed = false;
            }
        }
    }
}
