using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI continueText;
    [SerializeField] Button continueButton;
    [SerializeField] Color disabledColor, enabledColor;
    [Header("Test")]
    [SerializeField] GameObject newGameWarning;
    void Start() {
        newGameWarning.SetActive(false);
        PlayerData data = SaveSystem.LoadFile(); 
        if(data != null && data.gameStarted) {
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
        SceneManager.LoadScene("Introduction");
        PlayerProgress.instance.ResetProgress();

        continueButton.interactable = true;
        continueText.color = enabledColor;
    }

    public void ContinueGame() {
        SceneManager.LoadScene("LevelSelect");
        PlayerProgress.instance.GetProgress();
    }
}
