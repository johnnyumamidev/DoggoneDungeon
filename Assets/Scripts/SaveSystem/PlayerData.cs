using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public bool gameStarted;
    public int currentFloorIndex;
    public List<string> completedPuzzles = new List<string>();
    public PlayerData(PlayerProgress playerProgress) {
        gameStarted = playerProgress.gameStarted;
        currentFloorIndex = playerProgress.currentFloorIndex;
        completedPuzzles = playerProgress.completedPuzzles;
    }
}
