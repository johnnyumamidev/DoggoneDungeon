using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    UserInput userInput;
    Image transparency;

    [SerializeField] Button goToMapButton;
    // Start is called before the first frame update
    void Start()
    {
        DetermineGameState();

        transparency = GetComponent<Image>();
        userInput = FindObjectOfType<UserInput>();
        if(userInput) {
            Debug.Log(name + "subscribed");
            userInput.OnPause += EnableMenu;
        }
        pauseMenu.SetActive(false);   
        transparency.enabled = false;
    }
    void OnDisable() {
        if(userInput) {
            Debug.Log(name + "disabled");
            userInput.OnPause -= EnableMenu;
        }
    }
    public void EnableMenu() {
        Debug.Log(name);
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        transparency.enabled = !transparency.enabled;
        GameStateManager.Instance.PauseGame();
    }
    public void GoToTitleScreen() {
        GameStateManager.Instance.TransitionTo("MainMenu");
    }
    public void GoToMap() {
        GameStateManager.Instance.TransitionTo("LevelSelect");
    }
    void DetermineGameState() {
        PuzzleManager puzzleManager = FindObjectOfType<PuzzleManager>();
        DungeonMapManager dungeonMapManager = FindObjectOfType<DungeonMapManager>();

        if(puzzleManager) {
            goToMapButton.gameObject.SetActive(true);
        }
        else if(dungeonMapManager) {
            goToMapButton.gameObject.SetActive(false);
        }
    }
}
