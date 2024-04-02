using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour, IInteractable, ISwitch
{
    public UnityEvent<ISwitch> OnToggle;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool active = false;
    public void Cancel()
    {
        Debug.Log("cancel lever");
        active = !active;
        OnToggle?.Invoke(this);
    }

    public void Interact(Transform interactor)
    {
        active = !active;
        OnToggle?.Invoke(this);
    }

    public bool IsTriggered()
    {
        return active;
    }

    void Update() {
        if(!active)
            spriteRenderer.color = Color.red;
        else {
            spriteRenderer.color = Color.green;
        }
    }
}