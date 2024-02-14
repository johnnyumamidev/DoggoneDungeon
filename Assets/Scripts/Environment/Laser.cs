using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float laserLength = 5;
    public Transform LaserRay() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * laserLength);
        return hit.transform;
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * laserLength);
    }
}
