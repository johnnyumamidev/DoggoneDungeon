using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress Instance { get; private set; }
    public int levelsCompleted = 0;
    public bool gameStarted = false;

    public Vector2 playerPosition;
    void Start() {
        Instance = this;
    }
    public void OnLevelEntered() {
        gameStarted = true;
    }
    public void OnLevelCompleted() {
        levelsCompleted++;
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
    }

    public void SavePlayerPosition(Vector2 position) {
        playerPosition = position;
    }
}
