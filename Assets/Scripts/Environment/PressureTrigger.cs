using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressureTrigger : MonoBehaviour
{
    public UnityEvent<bool> testEvent;
    bool triggered = false;
    void Update()
    {
        triggered = GetColliders();
        testEvent?.Invoke(triggered);
    }

    bool GetColliders() {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.25f);
        if(collider && collider.TryGetComponent(out ITrigger trigger))
            return true;
        return false;
    }
}
