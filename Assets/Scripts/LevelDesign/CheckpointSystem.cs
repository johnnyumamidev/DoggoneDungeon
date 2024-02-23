using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    Checkpoint mostRecentCheckpoint;
    public void SetMostRecentCheckpoint(Checkpoint checkpoint) {
        mostRecentCheckpoint = checkpoint;
    }   
    public void PlacePlayerAtCheckpoint(Transform player) {
        player.position = mostRecentCheckpoint.transform.position;
    }
}
