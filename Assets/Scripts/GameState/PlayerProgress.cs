using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress Instance { get; private set; }
    public int levelsCompleted = 0;
    public bool gameStarted = false;
    public int currentFloorIndex = 0;
    public Vector2 playerPosition;
    public List<string> completedPuzzles = new List<string>();
    public int keysCollected = 0;
    public Dictionary<string, bool> unlockedLocks;
    void Awake() {
        Instance = this;
        unlockedLocks = new Dictionary<string, bool>();
    }
    public void OnLevelEntered() {
        gameStarted = true;
    }
    public void OnLevelCompleted(string levelName) {
        if(!completedPuzzles.Contains(levelName)) {
            completedPuzzles.Add(levelName);
            keysCollected++;
        }
    }
    public void ResetProgress() {
        gameStarted = false;
        levelsCompleted = 0;
    }
    public void GetProgress() {
        PlayerData data = SaveSystem.LoadFile();
        levelsCompleted = data.levelsCompleted;
        gameStarted = data.gameStarted;
        currentFloorIndex = data.currentFloorIndex;
        completedPuzzles = data.completedPuzzles;
        keysCollected = data.keysCollected;
        unlockedLocks = data.unlockedLocks;
    }
    public void SavePlayerPosition(Vector2 position) {
        playerPosition = position;
    }
    public void UseKey(string lockID, bool unlocked) {
        keysCollected--;
        if(unlockedLocks.ContainsKey(lockID))
            unlockedLocks.Remove(lockID);
        unlockedLocks.Add(lockID, unlocked);
    }
}
