using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        SceneManager.LoadScene("MainMenu");
    }
}
