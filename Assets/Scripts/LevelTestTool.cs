using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LevelTestTool : MonoBehaviour
{
    [SerializeField] Transform cameraTransform, playerTransform;
    [SerializeField] List<Transform> levelTransforms = new List<Transform>();
    [SerializeField] int levelIndex = 0;

    public void ChangeLevel() {
        if(levelIndex < levelTransforms.Count - 1)
            levelIndex++;
        else {
            levelIndex = 0;
        }
        Transform currentLevel = levelTransforms[levelIndex];
        playerTransform.position = new Vector3(currentLevel.position.x, currentLevel.position.y,0);
        Player player = playerTransform.GetComponent<Player>();
        TileData tileData = currentLevel.GetComponentInChildren<TileData>();
        player.SetTileData(tileData);

        Vector3 levelPosition = new Vector3(currentLevel.position.x, currentLevel.position.y,-10);
        cameraTransform.position = levelPosition;
    }
}
