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
    [SerializeField] RaycastHit2D laserHit;
    public Transform LaserRay(out Vector2 direction) {
        direction = directions[rotationIndex];
        if(!active) 
            return null;
        RaycastHit2D hit = Physics2D.Raycast(laserStart.position, direction);
        if(hit) {
            laserHit = hit;
            return hit.transform;
        }
        return null;
    }

    public void Activate(bool b) {
        active = b;
    }
    void Update() {
        HandleRotation();

        Vector2 laserVector = Vector2.down * 10;
        if(laserHit) {
            laserVector = laserHit.point - (Vector2)laserStart.position;         
        }
        laserStart.localScale = new Vector3(1, laserVector.magnitude, 1);
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
