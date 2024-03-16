using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressureTrigger : MonoBehaviour, ISwitch
{
    public UnityEvent<ISwitch> testEvent;
    bool triggered = false;
    [SerializeField] SpriteRenderer buttonRenderer;
    [SerializeField] Color disabledColor, enabledColor;
    void Update()
    {
        Collider2D triggerCheck = Physics2D.OverlapCircle(transform.position, 0.25f);

        if(!triggered) {
            if (triggerCheck && triggerCheck.TryGetComponent(out ITrigger trigger)) {
                triggered = true;
                testEvent?.Invoke(this);
            }
        }
        else {
            if(!triggerCheck) {
                triggered = false;
                testEvent?.Invoke(this);
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

    public bool IsTriggered()
    {
        return triggered;
    }
}
