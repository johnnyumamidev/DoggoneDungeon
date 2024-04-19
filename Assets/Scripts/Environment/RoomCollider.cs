using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollider : MonoBehaviour
{
    [Header("Target Room:")]
    [SerializeField] int roomNumber;
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        if(other.TryGetComponent(out Player player)) {
            CameraManager.instance.ChangeRoom(roomNumber);
        }
    }
}
