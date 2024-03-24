using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bridge : MonoBehaviour
{
    [SerializeField] TileBase bridgeTile;
    [SerializeField] TileData tileData;
    bool active;
    void OnEnable() {
        if(tileData == null)
            tileData = FindObjectOfType<TileData>();
    }
    public void Activate(bool b) {
        active = b;
    }
    void Update() {
        foreach(Transform spawnPoint in transform) {
            Vector3Int tilePosition = tileData.groundTilemap.WorldToCell(spawnPoint.position);
            if(active) {
                tileData.groundTilemap.SetTile(tilePosition, bridgeTile);
            }
            else {
                tileData.groundTilemap.SetTile(tilePosition, null);
            }
        }
    }
}
