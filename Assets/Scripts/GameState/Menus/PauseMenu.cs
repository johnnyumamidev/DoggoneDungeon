using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);   
    }
    public void EnableMenu(bool b) {
        pauseMenu.SetActive(b);
    }
    public void GoToTitleScreen() {
        GameStateManager.Instance.TransitionTo("MainMenu");
    }
    public void GoToMap() {
        GameStateManager.Instance.TransitionTo("LevelSelect");
    }
}
