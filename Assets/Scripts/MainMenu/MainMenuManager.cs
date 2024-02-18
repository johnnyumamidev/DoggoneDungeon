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
    void Start() {

    }
    public void StartNewGame() {
        SceneManager.LoadScene("LevelSelect");
        PlayerProgress.instance.ResetProgress();
    }

    public void ContinueGame() {
        SceneManager.LoadScene("LevelSelect");
        PlayerProgress.instance.GetProgress();
    }
}
