using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundDestroyer : MonoBehaviour
{
    TileData tileData;
    [SerializeField] Transform pointsParent;
    // Start is called before the first frame update
    void Start()
    {
        if(tileData == null)
            tileData = FindObjectOfType<TileData>();    
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform point in pointsParent) {
            Vector3Int tilePosition = tileData.groundTilemap.WorldToCell(point.position);
            if(tileData.groundTilemap.HasTile(tilePosition)) {
                tileData.groundTilemap.SetTile(tilePosition, null);
            }
        }
    }
}
