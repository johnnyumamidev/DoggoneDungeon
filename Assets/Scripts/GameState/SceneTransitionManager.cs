using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if(Instance == null)
            Instance = this;
        else {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionTo(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
