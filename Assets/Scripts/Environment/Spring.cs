using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] Transform springTarget;
    
    public void Activate() {
        Vector3 pushDirection = springTarget.position - transform.position;
        Collider2D colliderCheck = Physics2D.OverlapCircle(springTarget.position, 0.25f);
            if(!colliderCheck) { 
                Debug.Log("nothing to push");   
                return;
            }
        if(colliderCheck.TryGetComponent(out IPushable pushable)) {
            pushable.Push(pushDirection);
        }

    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(springTarget.position, 0.2f);
    }
}
