using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IUnit, ITrigger
{
    [SerializeField] TileData tileData;
    [SerializeField] LayerMask obstacleLayer;
    bool onMovingPlatform = false;
    public void Move(Vector2 input, bool undo)
    {
        Vector3 position = transform.position + (Vector3)input;
        Vector3 roundedPosition = new Vector3(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), 0);
        Collider2D obstacle = Physics2D.OverlapCircle(position, 0.25f, obstacleLayer);
        
        if(CanMove(position)) {
            if(obstacle) {
                IPushable pushable = obstacle.GetComponent<IPushable>();
                if(pushable == null)
                    return;

                Vector3 tileInFrontOfPushable = position + (Vector3)input; 
                if(!pushable.NoObstacles(tileInFrontOfPushable))
                    return;
            }
            transform.position = roundedPosition;
        } 
    }

    public bool CanMove(Vector3 target) {
        if(onMovingPlatform) {
            if(tileData.ValidTile(target)) {
                transform.parent = null;
                onMovingPlatform = false;
            } 
        }

        Collider2D platformCol = Physics2D.OverlapCircle(target, 0.25f); 
        if(platformCol && platformCol.TryGetComponent(out MovingPlatform _movingPlatform)) {
            if(!_movingPlatform.AtWayPoint()) 
                return false;
            transform.parent = _movingPlatform.transform;
            transform.localPosition = Vector3.zero;
            onMovingPlatform = true;
            return true;
        }
        
        if(tileData.ValidTile(target))
            return true;
        return false;
    }

    public void SetTileData(TileData _tileData) {
        tileData = _tileData;
    }
}
