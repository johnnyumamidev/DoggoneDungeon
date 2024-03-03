using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress Instance { get; private set; }
    public int levelsCompleted = 0;
    public bool gameStarted = false;
    void Awake() {
        if(Instance != null) {
            Debug.Log("More than one instance found in scene");
            Destroy(this.gameObject);
        }
        else {
            Instance = this;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void OnLevelCompleted() {
        gameStarted = true;
        levelsCompleted++;
        SaveSystem.SaveProgress(this);
    }

    public void ResetProgress() {
        gameStarted = true;
        levelsCompleted = 0;
    }

    public void GetProgress() {
        PlayerData data = SaveSystem.LoadFile();
        levelsCompleted = data.levelsCompleted;
    }
}
