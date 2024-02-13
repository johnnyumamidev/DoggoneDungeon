using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour, IUnit, ITrigger
{
    [SerializeField] TileData tileData;
    Vector2 target;
    public void Move(Vector2 input, bool undo)
    {
        if(CanMove(transform.position + (Vector3)input))
            target = transform.position + (Vector3)input;
            transform.position = target;
    }

    public bool CanMove(Vector3 target) {
        if(tileData.ValidTile(target))
            return true;
        return false;
    }
}
