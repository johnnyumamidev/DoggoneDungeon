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
    bool laserHit = false;
    RaycastHit2D hit;
    Vector2 laserLength = Vector2.down * 20;
    public Transform LaserRay(out Vector2 direction) {
        direction = directions[rotationIndex];
        if(!active) 
            return null;
        hit = Physics2D.Raycast(laserStart.position, direction);
        if(hit) {
            laserHit = true;
            return hit.transform;
        }
        else {
            laserHit = false;
        }
        return null;
    }

    public void Activate(bool b) {
        active = b;
    }
    void Update() {
        HandleRotation();

        if(laserHit) {
            Vector2 laserVector = hit.point - (Vector2)laserStart.position;  
            laserStart.localScale = new Vector3(1, laserVector.magnitude, 1);
        }
        else {
            laserStart.localScale = new Vector3(1, laserLength.magnitude, 1);
        }
    }
    void HandleRotation() {
        transform.rotation = Quaternion.Euler(0,0,rotationAngles[rotationIndex]);
    }
    public void Interact(Transform interactor)
    {
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
