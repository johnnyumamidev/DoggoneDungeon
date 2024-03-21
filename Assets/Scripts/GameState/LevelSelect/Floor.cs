using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Floor : MonoBehaviour
{
    [SerializeField] TileData tileData;
    [SerializeField] GameObject floorMap;
    [SerializeField] Transform start;
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

        for(int i = 0; i < levelNodes.Count; i++) {
            if(i <= PlayerProgress.Instance.completedPuzzles.Count) {
                levelNodes[i].UnlockLevel();
            }
        }
    }
    void Update() {
        
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
