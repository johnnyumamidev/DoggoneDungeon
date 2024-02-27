using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour, IInteractable
{
    List<float> rotationAngles = new List<float> {
        0, 90, 180, -90
    };
    List<Vector2> directions = new List<Vector2> {
        Vector2.down, Vector2.right, Vector2.up, Vector2.left
    };
    [SerializeField] int rotationIndex = 0;
    int previousIndex;
    [SerializeField] Transform laserStart;
    [SerializeField] bool active = false;
    float laserLength = 5;
    public Transform LaserRay() {
        if(!active) return null;
        RaycastHit2D hit = Physics2D.Raycast(laserStart.position, directions[rotationIndex] * laserLength);
        if(hit && hit.transform.TryGetComponent(out Battery battery))
            return hit.transform;
        return null;
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(laserStart.position, directions[rotationIndex] * laserLength);
    }

    public void Activate(bool b) {
        active = b;
    }
    void Update() {
        HandleRotation();
    }
    void HandleRotation() {
        transform.rotation = Quaternion.Euler(0,0,rotationAngles[rotationIndex]);
    }
    public void Interact()
    {
        Debug.Log(name);
        previousIndex = rotationIndex;
        if(rotationIndex < rotationAngles.Count-1) {
            rotationIndex++;
        }
        else {
            rotationIndex = 0;
        }
    }

    public void Cancel()
    {
        rotationIndex = previousIndex;
    }
}
