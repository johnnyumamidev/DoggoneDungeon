using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Floor : MonoBehaviour
{
    [SerializeField] TileData tileData;
    [SerializeField] GameObject floorMap;
    [SerializeField] Transform start;
    [SerializeField] TileBase catTile;
    [SerializeField] Tilemap wallTilemap;
    [SerializeField] Transform catGuardTransform;
    [SerializeField] Transform levelNodesParent;
    [SerializeField] List<LevelNode> levelNodes = new List<LevelNode>();
    void Awake() {
        if(floorMap == null)
            floorMap = gameObject;
    }
    void Start() {
        foreach(Transform node in levelNodesParent) {
            LevelNode level = node.GetComponent<LevelNode>();
            levelNodes.Add(level);
        }

        foreach(LevelNode node in levelNodes) {
            node.OnPlayerDetected += EnterLevel;
        }

        for(int i = 0; i < levelNodes.Count; i++) {
            if(i <= PlayerProgress.Instance.completedPuzzles.Count) {
                levelNodes[i].UnlockLevel();
            }
        }
    }
    void OnDisable() {
        foreach(LevelNode node in levelNodes) {
            node.OnPlayerDetected -= EnterLevel;
        }
    }
    void Update() {
        HandleGuard();
    }
    private void HandleGuard() {
        Vector3Int tilePosition = wallTilemap.WorldToCell(catGuardTransform.position);
        if (!AllLevelsCleared())
            wallTilemap.SetTile(tilePosition, catTile);
        else {
            wallTilemap.SetTile(tilePosition, null);
        }   
    }
    bool AllLevelsCleared() {
        List<LevelNode> completedLevels = new List<LevelNode>();
        for(int i = 0; i < levelNodes.Count; i++) {
            if(PlayerProgress.Instance.completedPuzzles.Count <= i)
                continue;
            
            LevelNode level = levelNodes[i];
            if(level.levelName == PlayerProgress.Instance.completedPuzzles[i]) {
                completedLevels.Add(levelNodes[i]);
            }
        }
        
        return completedLevels.Count == levelNodes.Count;
    }
    void EnterLevel(LevelNode levelNode, bool unlocked) {
        if(Input.GetKeyDown(KeyCode.Space) && unlocked) {
            string scene = "PuzzleLevel";
            GameStateManager.Instance.TransitionTo(scene);
            GameStateManager.Instance.SetCurrentLevel(levelNode);
            PlayerProgress.Instance.OnLevelEntered();
        }
    }
    public void EnterFloor(Player player) {
        floorMap.SetActive(true);
        player.SetTileData(tileData);

        if(!PlayerProgress.Instance.gameStarted) // OR NEW FLOOR STARTED
            player.transform.position = start.position;
        else {
            player.transform.position = PlayerProgress.Instance.playerPosition;
        }
    }
    public void ExitFloor() {
        floorMap.SetActive(false);
    }
}
