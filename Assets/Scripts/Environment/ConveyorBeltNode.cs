using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltNode : MonoBehaviour
{
    public enum Direction { Up, Down, Left, Right }
    [SerializeField] Direction direction;
    [SerializeField] Transform directionTarget;
    Transform pushableTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.25f);
        if(collider && (collider.TryGetComponent(out IPushable pushable) || collider.TryGetComponent(out Player player)))
            pushableTransform = collider.transform;
        else {
            pushableTransform = null;
        }
    }
    public void MoveTriggerTransform() {
        Vector3 moveDirection = directionTarget.position - transform.position;
        Collider2D obstacle = Physics2D.OverlapCircle(directionTarget.position, 0.25f);
        if(pushableTransform != null && !obstacle) {
            pushableTransform.position += moveDirection;
            if(pushableTransform.parent != null) {
                pushableTransform.parent = null;
            }
        }
    }
}
