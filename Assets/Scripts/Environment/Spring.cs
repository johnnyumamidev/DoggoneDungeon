using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spring : MonoBehaviour, ITicker
{
    [SerializeField] Transform springTarget;
    [SerializeField] bool activated = false;
    public float cooldownLength = 2f; 
    void Update() {
        ChangeSpringColor();
    }
    public void Activate(ISwitch _switch) {
        activated = _switch.IsTriggered();
    }
    void ChangeSpringColor() {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if(activated)
            spriteRenderer.color = Color.red;
        else {
            spriteRenderer.color = Color.white;
        }
    }
    void CheckForPushables() {
        Vector3 pushDirection = springTarget.position - transform.position;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, pushDirection, pushDirection.magnitude);
        if(hits.Length == 0) { 
            return;
        }
        for(int i = 0; i < hits.Length; i++) {
            Transform hit = hits[i].transform;
            if(hit.TryGetComponent(out IPushable pushable)) {
                pushable.Push(pushDirection);
            }
        }
    }
    public void Tick()
    {
        if(activated) {
            CheckForPushables();
        }
    }
}
