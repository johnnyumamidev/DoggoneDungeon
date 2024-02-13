using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Transform leftDoor, rightDoor;
    [SerializeField] Vector3 leftOpenPosition, leftClosedPosition, rightOpenPosition, rightClosedPosition;
    Vector3 leftTarget, rightTarget;
    public float doorSpeed = 5f;
    bool open = false;
    Collider2D doorCollider;
    void Awake() {
        doorCollider = GetComponent<Collider2D>();
    }
    public void ControlDoors(bool b) {
        open = b;
        if(!open) {
            leftTarget = leftClosedPosition;
            rightTarget = rightClosedPosition;
        }
        else {
            leftTarget = leftOpenPosition;
            rightTarget = rightOpenPosition;
        }
    }

    void Update() {
        doorCollider.enabled = !open;
        leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftTarget, doorSpeed * Time.deltaTime);
        rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightTarget, doorSpeed * Time.deltaTime);
    }
}
