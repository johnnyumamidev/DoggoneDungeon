using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCommand : ICommand
{
    Transform unitTransform;
    Vector2 input;
    LayerMask interactableLayer;
    IInteractable interactable;
    public InteractCommand(Transform _unitTransform, Vector2 _input, LayerMask _interactable) {
        unitTransform = _unitTransform;
        input = _input;
        interactableLayer = _interactable;
    }
    public void Execute()
    {
        Vector3 checkPosition = unitTransform.position + (Vector3)input;
        Collider2D collider = Physics2D.OverlapCircle(checkPosition, 0.1f, interactableLayer);
        if(collider) {
            interactable = collider.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }

    public void Undo()
    {
        Debug.Log(interactable == null);
        interactable?.Cancel();
    }
}
