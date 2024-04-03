using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress Instance { get; private set; }
    public bool gameStarted = false;
    public int currentFloorIndex = 0;
    public Vector2 playerPosition;
    public List<string> completedPuzzles = new List<string>();
    void Awake() {
        Instance = this;
    }
    public void OnTutorialComplete() {
        gameStarted = true;

        SaveSystem.SaveProgress(this);
    }
    public void OnLevelCompleted(string levelName) {
        if(!completedPuzzles.Contains(levelName)) {
            completedPuzzles.Add(levelName);
        }

        SaveSystem.SaveProgress(this);
    }
    public void OnFloorCompleted(int floorIndex) {
        currentFloorIndex = floorIndex;

        SaveSystem.SaveProgress(this);
    }
    public void ResetProgress() {
        gameStarted = false;
        currentFloorIndex = 0;
        completedPuzzles.Clear();
        SaveSystem.SaveProgress(this);
    }
    public void GetProgress() {
        Debug.Log("getting save data");
        PlayerData data = SaveSystem.LoadFile();
        gameStarted = data.gameStarted;
        currentFloorIndex = data.currentFloorIndex;
        completedPuzzles = data.completedPuzzles;
        playerPosition = data.playerPosition;
    }
    public void SavePlayerPosition(Vector2 position) {
        playerPosition = position;

        SaveSystem.SaveProgress(this);
    }
}
