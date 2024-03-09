using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }
    public bool gamePaused = false;
    public LevelNode CurrentLevel { get; private set; }
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
        if(sceneName == "PuzzleLevel") {
            PlayerProgress.Instance.SavePlayerPosition(FindObjectOfType<Player>().transform.position);
        }
       
        SceneManager.LoadScene(sceneName);
    }
    public void SetCurrentLevel(LevelNode _levelNode) {
        CurrentLevel = _levelNode;
    }
    public void PauseGame() {
        gamePaused = !gamePaused;
    }
}