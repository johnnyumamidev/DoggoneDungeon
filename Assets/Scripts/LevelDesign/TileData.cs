using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileData : MonoBehaviour
{
    public Tilemap groundTilemap, wallsTilemap;

    public bool ValidTile(Vector2 target) {
        Vector3Int gridPosition = groundTilemap.WorldToCell(target);
        bool onGround = groundTilemap.HasTile(gridPosition);
        bool noWall = !wallsTilemap.HasTile(gridPosition);
        if(onGround && noWall)
            return true;
        return false;
    } 
}
