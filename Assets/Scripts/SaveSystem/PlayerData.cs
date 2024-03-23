using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int levelsCompleted;
    public bool gameStarted;
    public int currentFloorIndex;
    public List<string> completedPuzzles = new List<string>();
    public int keysCollected = 0;
    public Dictionary<string, bool> unlockedLocks = new Dictionary<string, bool>();
    public PlayerData(PlayerProgress playerProgress) {
        levelsCompleted = playerProgress.levelsCompleted;
        gameStarted = playerProgress.gameStarted;
        currentFloorIndex = playerProgress.currentFloorIndex;
        completedPuzzles = playerProgress.completedPuzzles;
        keysCollected = playerProgress.keysCollected;
        unlockedLocks = playerProgress.unlockedLocks;
    }
}
