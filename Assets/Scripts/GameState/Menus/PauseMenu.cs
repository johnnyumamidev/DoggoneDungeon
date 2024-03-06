using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    UserInput userInput;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);   
        userInput = FindObjectOfType<UserInput>();
        if(userInput) {
            userInput.OnPause += EnableMenu;
        }
    }
    void OnDisable() {
        if(userInput)
            userInput.OnPause -= EnableMenu;
    }
    public void EnableMenu() {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        GameStateManager.Instance.PauseGame();
    }
    public void GoToTitleScreen() {
        GameStateManager.Instance.TransitionTo("MainMenu");
        GameStateManager.Instance.PauseGame();
    }
    public void GoToMap() {
        GameStateManager.Instance.TransitionTo("LevelSelect");
        GameStateManager.Instance.PauseGame();
    }
}
