using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject newGameWarning;
    public TextMeshProUGUI continueText;
    public Button continueButton;
    public Button newGamebutton;
    [SerializeField] Color disabledColor, enabledColor;
    void Start() {
        newGameWarning.SetActive(false);
        PlayerData data = SaveSystem.LoadFile();

        if (data != null && data.gameStarted)
        {
            Debug.Log("game file exists");
            PlayerProgress.Instance.GetProgress();
            continueButton.interactable = true;
            continueText.color = enabledColor;
        }
    }
    public void CheckForSaveData() {
        PlayerData data = SaveSystem.LoadFile(); 
        if(data != null && data.gameStarted) {
            newGameWarning.SetActive(true);
        }
        else {
            StartNewGame();
        }
    }
    public void StartNewGame() {
        PlayerProgress.Instance.ResetProgress();
        GameStateManager.Instance.TransitionTo("TutorialLevel");
    }

    public void ContinueGame() {
        GameStateManager.Instance.TransitionTo("LevelSelect");
        PlayerProgress.Instance.GetProgress();
    }

    public void CloseApp() {
        Application.Quit();
    }
    public void OpenTestEnvironment() {
        GameStateManager.Instance.TransitionTo("TestEnvironment");
    }
}

