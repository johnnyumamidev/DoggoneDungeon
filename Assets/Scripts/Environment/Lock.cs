using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Lock : MonoBehaviour
{
    [SerializeField] TileBase cageTile;
    [SerializeField] Tilemap wallsTilemap;
    public bool locked = true;
    void Update()
    {
        ControlCage();
    }
    
    void ControlCage() {
        Vector3Int tilePosition = wallsTilemap.WorldToCell(transform.position);
        if(locked) 
            wallsTilemap.SetTile(tilePosition, cageTile);
        else {
            wallsTilemap.SetTile(tilePosition, null);
        }
    }

    public void ControlLock(bool a) {
        locked = !a;
    }
}
