using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCommand : ICommand
{
    Transform unitTransform;
    Vector2 input;
    IPushable pushable;
    Vector3 pushablePreviousPosition;
    LayerMask interactable;
    public PushCommand(Transform _unitTransform, Vector2 _input, LayerMask _interactable) {
        unitTransform = _unitTransform;
        input = _input;
        interactable = _interactable;
    }
    public void Execute()
    {
        Vector3 checkPosition = unitTransform.position + (Vector3)input;
        Collider2D col = Physics2D.OverlapCircle(checkPosition, 0.25f, interactable);
        
        if(col) {
            pushablePreviousPosition = col.transform.position;
            pushable = col.GetComponent<IPushable>();
            pushable?.Push(input);
        }
    }

    public void Undo()
    {
        pushable?.Push(pushablePreviousPosition - ((MonoBehaviour)pushable).transform.position);
    }
}
