using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneMenuManager : MonoBehaviour
{
    public void SkipCutscene() {
        SceneManager.LoadScene("LevelSelect");
    }
}
