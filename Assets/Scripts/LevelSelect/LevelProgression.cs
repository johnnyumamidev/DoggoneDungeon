using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    public static LevelProgression instance { get; private set; }
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
    }
}
