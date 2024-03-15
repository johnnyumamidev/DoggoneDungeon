using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressureTrigger : MonoBehaviour
{
    public UnityEvent<bool> testEvent;
    bool triggered = false;
    [SerializeField] SpriteRenderer buttonRenderer;
    [SerializeField] Color disabledColor, enabledColor;
    void Update()
    {
        if(!triggered) {
            Collider2D triggerCheck = Physics2D.OverlapCircle(transform.position, 0.25f);
            if (triggerCheck && triggerCheck.TryGetComponent(out ITrigger trigger)) {
                triggered = true;
                Debug.Log("trigger");
                testEvent?.Invoke(true);
            }
        }
        else {
            Collider2D triggerCheck = Physics2D.OverlapCircle(transform.position, 0.25f);
            if(!triggerCheck) {
                triggered = false;
                testEvent?.Invoke(false);
            }
        }
        HandleColor();
    }

    private void HandleColor()
    {
        buttonRenderer.color = enabledColor;
        if (!triggered)
            buttonRenderer.color = disabledColor;
    }
}
