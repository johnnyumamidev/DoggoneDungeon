using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int levelsCompleted;
    public bool gameStarted;
    public PlayerData(PlayerProgress playerProgress) {
        levelsCompleted = playerProgress.levelsCompleted;
        gameStarted = playerProgress.gameStarted;
    }
}
