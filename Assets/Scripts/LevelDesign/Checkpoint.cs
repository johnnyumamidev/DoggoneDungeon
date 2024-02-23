using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    CheckpointSystem checkpointSystem;
   
    void Awake() {
        if(checkpointSystem == null) 
            checkpointSystem = FindObjectOfType<CheckpointSystem>();
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.TryGetComponent(out Player player))
        {
            checkpointSystem.SetMostRecentCheckpoint(this);
        }
    }
}
