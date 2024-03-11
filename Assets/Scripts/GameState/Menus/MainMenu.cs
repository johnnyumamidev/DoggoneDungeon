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
        Debug.Log("gameStarted? " + data.gameStarted);

        if (data != null && data.gameStarted)
        {
            Debug.Log("game file exists");
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
        GameStateManager.Instance.TransitionTo("LevelSelect");
        PlayerProgress.Instance.ResetProgress();
    }

    public void ContinueGame() {
        GameStateManager.Instance.TransitionTo("LevelSelect");
        PlayerProgress.Instance.GetProgress();
    }
}

