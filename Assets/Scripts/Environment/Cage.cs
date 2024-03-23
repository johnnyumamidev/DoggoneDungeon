using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cage : MonoBehaviour
{
    [SerializeField] TileBase cageTile;
    [SerializeField] TileData tileData;
    bool locked = true;
    void OnEnable() {
        if(tileData == null)
            tileData = FindObjectOfType<TileData>();
    }
    void Update()
    {
        ControlCage();
    }
    void ControlCage() {
        Vector3Int tilePosition = tileData.wallsTilemap.WorldToCell(transform.position);
        if(locked) 
            tileData.wallsTilemap.SetTile(tilePosition, cageTile);
        else {
            tileData.wallsTilemap.SetTile(tilePosition, null);
        }
    }

    public void Unlock() {
        locked = false;
    }
}
