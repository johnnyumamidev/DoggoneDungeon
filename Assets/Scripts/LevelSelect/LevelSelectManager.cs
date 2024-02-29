using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] WorldMapManager worldMapManager;
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] List<Transform> levelNodesParents = new List<Transform>();
    [SerializeField] List<LevelNode> levelNodes = new List<LevelNode>();
    void Start() {
        foreach(Transform levelNodesParent in levelNodesParents) {
            foreach(Transform node in levelNodesParent) {
                levelNodes.Add(node.GetComponent<LevelNode>());
            }
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

    void Test(LevelNode levelNode, bool unlocked) {
        if(unlocked)
            displayText.text = levelNode.name;
        else {
            displayText.text = levelNode.name + " (LOCKED)";   
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && unlocked) {
            SceneManager.LoadScene(levelNode.name);
        }
    }
}