using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Start() {
        DontDestroyOnLoad(this);
    }
    public void GoToLevelSelectScreen() {
        SceneManager.LoadScene("LevelSelect");
    } 
}
