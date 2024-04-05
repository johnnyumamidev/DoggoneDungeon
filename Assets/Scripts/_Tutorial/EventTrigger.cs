using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent OnTriggered;
    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.TryGetComponent(out Player player)) {
            OnTriggered?.Invoke();
        }
    }
}
