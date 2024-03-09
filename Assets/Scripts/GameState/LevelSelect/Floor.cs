using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Floor : MonoBehaviour
{
    [SerializeField] TileData tileData;
    [SerializeField] GameObject floorMap;
    [SerializeField] Transform start;
    public bool exitBlocked = true;
    [SerializeField] TileBase catTile;
    [SerializeField] Tilemap wallTilemap;
    [SerializeField] Transform catGuardTransform;
    void Awake() {
        if(floorMap == null)
            floorMap = gameObject;
    }
    public void EnterFloor(Player player) {
        floorMap.SetActive(true);
        player.SetTileData(tileData);

        if(!PlayerProgress.Instance.gameStarted)
            player.transform.position = start.position;
        else {
            player.transform.position = PlayerProgress.Instance.playerPosition;
        }
    }

    void Update() {
        Vector3Int tilePosition = wallTilemap.WorldToCell(catGuardTransform.position);
        if(exitBlocked) {
            wallTilemap.SetTile(tilePosition, catTile);
        }
        else {
            wallTilemap.SetTile(tilePosition, null);
        }   
    }
}
