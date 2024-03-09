using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DungeonMapManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] Player player;
    [SerializeField] UserInput userInput;
    [SerializeField] List<Floor> floors = new List<Floor>();
    [SerializeField] int currentFloorIndex = 0;
    [SerializeField] List<Transform> levelNodesParents = new List<Transform>();
    [SerializeField] List<LevelNode> levelNodes = new List<LevelNode>();
    void Awake() {
        if(player == null) 
            player = FindObjectOfType<Player>();
        if(userInput == null) 
            userInput = FindObjectOfType<UserInput>();
    }

    void Start() {
        userInput.GetPlayer();
        foreach(Transform levelNodesParent in levelNodesParents) {
            foreach(Transform node in levelNodesParent) {
                levelNodes.Add(node.GetComponent<LevelNode>());
            }
        }
        foreach(LevelNode node in levelNodes) {
            node.OnPlayerDetected += EnterLevel;
        }
        
        int index = PlayerProgress.Instance.levelsCompleted;
        for(int i = 0; i <= index; i++) {
            if(index > levelNodes.Count) return;
            levelNodes[i].UnlockLevel();
        }

        floors[currentFloorIndex].EnterFloor(player);
    }
    void OnDisable() {
        foreach(LevelNode node in levelNodes) {
            node.OnPlayerDetected -= EnterLevel;
        }
    }

    void EnterLevel(LevelNode levelNode, bool unlocked) {
        displayText.text = levelNode.name;

        if(Input.GetKeyDown(KeyCode.Space) && unlocked) {
            string scene = "PuzzleLevel";
            GameStateManager.Instance.TransitionTo(scene);
            GameStateManager.Instance.SetCurrentLevel(levelNode);
            PlayerProgress.Instance.OnLevelEntered();
        }
    }

    void Update()
    {
        Floor floor = floors[currentFloorIndex]; 
        if(LevelsCleared() >= levelNodes.Count)
            floor.exitBlocked = false;
        else {
            floor.exitBlocked = true;
        }
        
        displayText.text = " ";
    }

    int LevelsCleared() {
        List<LevelNode> unlockedLevels = new List<LevelNode>();
        foreach(LevelNode node in levelNodes) {
            if(node.unlocked)
                unlockedLevels.Add(node);
        }
        return unlockedLevels.Count;
    }
}
