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
        transform.parent = null;
        if(CanMove(transform.position + (Vector3)input))
            target = transform.position + (Vector3)input;
            transform.position = target;
    }

    public bool CanMove(Vector3 target) {
        if(tileData.ValidTile(target))
            return true;

        Collider2D collider = Physics2D.OverlapCircle(target, 0.25f);
        if(collider && collider.TryGetComponent(out MovingPlatform movingPlatform)) {
            transform.parent = movingPlatform.transform;
            return true;
        }
        return false;
    }
}
