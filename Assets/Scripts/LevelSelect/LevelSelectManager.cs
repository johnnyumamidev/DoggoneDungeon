using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
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
    
    void Test(LevelNode levelNode) {
        if(Input.GetKeyDown(KeyCode.Space))
            Debug.Log(levelNode.name);
    }
}
