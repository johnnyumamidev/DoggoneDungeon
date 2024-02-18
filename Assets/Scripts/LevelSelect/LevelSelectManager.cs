using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelDisplayText;
    [SerializeField] Transform levelNodesParent;
    [SerializeField] List<LevelNode> levelNodes = new List<LevelNode>();
    void Start() {
        foreach(Transform node in levelNodesParent) {
            levelNodes.Add(node.GetComponent<LevelNode>());
        }
        foreach(LevelNode node in levelNodes) {
            node.OnPlayerDetected += Test;
        }
        
        int index = PlayerProgress.instance.levelsCompleted;
        for(int i = 0; i <= index; i++) {
            if(index > levelNodes.Count) return;
            levelNodes[i].UnlockLevel();
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