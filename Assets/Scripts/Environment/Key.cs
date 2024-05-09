using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour, IPushable
{
    [SerializeField] UnityEvent keyUsed;
    [SerializeField] TileData tileData;
    [SerializeField] int obstacle;
    Vector3 target;
    [SerializeField] float speed = 20;

    void OnEnable() {
        if(tileData == null)
            tileData = FindObjectOfType<TileData>();
        
        obstacle = LayerMask.NameToLayer("Obstacle");
    }
    void Start() {
        target = transform.position;
    }
    public bool NoObstacles(Vector2 target)
    {
        Collider2D collider = Physics2D.OverlapCircle(target, 0.25f);
        if(!collider)
            return true;

        if(collider.gameObject.layer == obstacle)
            return false;

        if(!tileData.ValidTile(target)) {
            if(collider.TryGetComponent(out Cage cage))
                return true;
            else {
                return false;
            }
        }
        return true;
    }

    public void Push(Vector2 vector)
    {
        Vector3 target = transform.position + (Vector3)vector;
        if(NoObstacles(target) || OnMovingPlatform(target)) {
            if(!OnMovingPlatform(vector)) 
                transform.parent = null;
            target += (Vector3)vector;
        }
    }

    void Update() {
        //Check for cage
        Collider2D cageCheck = Physics2D.OverlapCircle(transform.position, 0.25f);
        if(cageCheck && cageCheck.TryGetComponent(out Cage cage)) {
            cage.Unlock();
            keyUsed?.Invoke();
            Destroy(gameObject);
        }
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
    }

    public bool OnMovingPlatform(Vector2 vector)
    {
        Collider2D collider = Physics2D.OverlapCircle(vector, 0.25f);
        if(collider && collider.TryGetComponent(out MovingPlatform movingPlatform)) {
            transform.parent = movingPlatform.transform;
            return true;
        }
        return false;
    }
}
