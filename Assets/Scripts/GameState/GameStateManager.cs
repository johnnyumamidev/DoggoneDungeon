using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }
    public bool gamePaused = false;
    void Awake() {
        if(Instance == null)
            Instance = this;
        else {
            Destroy(gameObject);
        }
    }
    void Start() {
        DontDestroyOnLoad(this);
    }
    public void TransitionTo(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGame() {
        gamePaused = !gamePaused;
    }
}