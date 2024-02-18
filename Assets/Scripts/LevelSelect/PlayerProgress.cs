using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress instance { get; private set; }
    public int levelsCompleted = 0;
    void Awake() {
        if(instance != null) {
            Debug.Log("More than one instance found in scene");
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void OnLevelCompleted() {
        levelsCompleted++;
        SaveSystem.SaveProgress(this);
    }
    public void ResetProgress() {
        levelsCompleted = 0;
    }

    public void GetProgress() {
        PlayerData data = SaveSystem.LoadFile();
        levelsCompleted = data.levelsCompleted;
    }
}
