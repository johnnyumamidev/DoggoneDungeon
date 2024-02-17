using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelDisplayText;
    LevelNode[] levelNodes;
    void Start() {
        levelNodes = FindObjectsOfType<LevelNode>();
        foreach(LevelNode node in levelNodes) {
            node.OnPlayerDetected += Test;
        }
    }
    void OnDisable() {
        foreach(LevelNode node in levelNodes) {
            node.OnPlayerDetected -= Test;
        }
    }

    void Update() {
        levelDisplayText.text = " ";

        
    }
    
    void Test(LevelNode levelNode, bool unlocked) {
        if(unlocked)
            levelDisplayText.text = levelNode.name;
        else {
            levelDisplayText.text = levelNode.name + " (LOCKED)";   
        }

        if(Input.GetKeyDown(KeyCode.Space) && unlocked) {
            SceneManager.LoadScene(levelNode.name);
        }
    }
}