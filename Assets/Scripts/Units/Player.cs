using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour, IUnit, ITrigger
{
    [SerializeField] TileData tileData;
    Vector2 target;
    [SerializeField] LayerMask obstacleLayer;
    public void Move(Vector2 input, bool undo)
    {
        transform.parent = null;
        Vector3 position = transform.position + (Vector3)input;
        Collider2D obstacle = Physics2D.OverlapCircle(position, 0.25f, obstacleLayer);
        if(CanMove(position) && !obstacle)
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
