using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] Transform laserStart;
    [SerializeField] bool active = false;
    float laserLength = 5;
    public Transform LaserRay() {
        if(!active) return null;
        RaycastHit2D hit = Physics2D.Raycast(laserStart.position, Vector2.down * laserLength);
        if(hit && hit.transform.TryGetComponent(out Battery battery))
            return hit.transform;
        return null;
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(laserStart.position, Vector3.down * laserLength);
    }

    public void Activate(bool b) {
        active = b;
    }
}
