using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour, IUnit, ITrigger
{
    [SerializeField] TileData tileData;
    [SerializeField] LayerMask obstacleLayer;
    bool onMovingPlatform = false;
    public Dog dogFollower;
    public void Move(Vector2 input, bool undo)
    {
        Vector3 position = transform.position + (Vector3)input;
        Vector3 roundedPosition = new Vector3(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), 0);
        Collider2D obstacle = Physics2D.OverlapCircle(position, 0.25f, obstacleLayer);
        
        if(CanMove(position, obstacle)) {
            if(obstacle) {
                IPushable pushable = obstacle.GetComponent<IPushable>();
                if(pushable == null) {
                    //do nothing   
                }
                else {
                    Vector3 tileInFrontOfPushable = position + (Vector3)input; 
                    if(!pushable.NoObstacles(tileInFrontOfPushable))
                        return;
                    
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.25f);
                    foreach(Collider2D collider in colliders) {
                        if(collider.TryGetComponent(out Spikes spikes)) {
                            return;
                        }
                    }
                }
            }
            transform.position = roundedPosition;
        } 

        if(dogFollower) {
            dogFollower.FollowPlayer(transform, input);
        }
    }

    public bool CanMove(Vector3 target, Collider2D obstacle) {
        if(onMovingPlatform) {
            if(tileData.ValidTile(target)) {
                transform.parent = null;
                onMovingPlatform = false;
            } 
        }

        Collider2D colliderCheck = Physics2D.OverlapCircle(target, 0.25f); 
        if(colliderCheck) {
            if(colliderCheck.TryGetComponent(out MovingPlatform _movingPlatform)) {
                if(!_movingPlatform.AtWayPoint() || obstacle) 
                    return false;
                transform.parent = _movingPlatform.transform;
                transform.localPosition = Vector3.zero;
                onMovingPlatform = true;
                return true;
            }

            if(colliderCheck.TryGetComponent(out IInteractable interactable)) 
                return false;
            
            if(colliderCheck.TryGetComponent(out Dog dog)) {
                if(!dogFollower)
                    dogFollower = dog;
                return false;
            }
        }
        
        if(tileData && tileData.ValidTile(target))
            return true;
        return false;
    }

    public void SetTileData(TileData _tileData) {
        tileData = _tileData;
    }

    void Update() {
        if(tileData == null) 
            return;

        if(!tileData.ValidTile(transform.position) && !onMovingPlatform) {
            CheckpointSystem checkpointSystem = FindObjectOfType<CheckpointSystem>();
            checkpointSystem?.PlacePlayerAtCheckpoint(transform);
        }
    }

    public void CommandDogToSit() {
        Debug.Log("sit");
        dogFollower = null;
    }
}
