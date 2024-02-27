using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bridge : MonoBehaviour
{
    Transform[] conveyorNodeChildren;
    [SerializeField] TileBase bridgeTile;
    [SerializeField] Tilemap groundTilemap;
    bool active;
    public void Activate(bool b) {
        active = b;
    }
    void Update() {
        Vector3Int tilePosition = groundTilemap.WorldToCell(transform.position);
        if(active) {
            groundTilemap.SetTile(tilePosition, bridgeTile);
        }
        else {
            groundTilemap.SetTile(tilePosition, null);
        }

        EnableChildren(active);
    }
    void EnableChildren(bool a) {
        foreach(Transform child in transform) {
            child.gameObject.SetActive(a);
        }
    }
}
