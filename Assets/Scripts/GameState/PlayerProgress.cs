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
    public int keyCount = 0;
    void Awake() {
        Instance = this;
    }
    public void OnLevelEntered() {
        gameStarted = true;
    }
    public void OnLevelCompleted(string levelName) {
        if(!completedPuzzles.Contains(levelName)) {
            completedPuzzles.Add(levelName);
        }

        SaveSystem.SaveProgress(this);
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
        keyCount = data.keyCount;
    }
    public void SavePlayerPosition(Vector2 position) {
        playerPosition = position;
    }
    public void CollectKey() {
        keyCount++;
    }
}
