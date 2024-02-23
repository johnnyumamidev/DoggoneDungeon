using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class LevelTestTool : MonoBehaviour
{
    [SerializeField] Transform cameraTransform, playerTransform;
    public List<LevelData> levels = new List<LevelData>();
    [SerializeField] int levelIndex = -1;
    
    void Start() {
        ChangeLevel();
    }
    public void ChangeLevel() {
        if(levelIndex < levels.Count - 1)
            levelIndex++;
        else {
            levelIndex = 0;
        }

        Transform currentLevel = levels[levelIndex].transform;
        Player player = playerTransform.GetComponent<Player>();
        TileData tileData = currentLevel.GetComponentInChildren<TileData>();

        Vector3 levelPosition = new Vector3(currentLevel.position.x, currentLevel.position.y,-10);
        playerTransform.position = new Vector3(currentLevel.position.x, currentLevel.position.y,0);
        
        player.SetTileData(tileData);
        cameraTransform.position = levelPosition;
        Camera.main.orthographicSize = levels[levelIndex].cameraSize;
    }
}
