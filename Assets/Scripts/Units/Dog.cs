using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public void FollowPlayer(Transform playerTransform, Vector2 moveDirection) {
        Vector3 followTarget = playerTransform.position - (Vector3)moveDirection;
        transform.position = followTarget;
    }
}
