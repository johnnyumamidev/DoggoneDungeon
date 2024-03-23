using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IPushable
{
    [SerializeField] TileData tileData;
    [SerializeField] LayerMask obstacle;

    void OnEnable() {
        if(tileData == null)
            tileData = FindObjectOfType<TileData>();
    }
    public bool NoObstacles(Vector2 target)
    {
        Collider2D collider = Physics2D.OverlapCircle(target, 0.25f, obstacle);
        if(collider || !tileData.ValidTile(target))
            return false;
        return true;
    }

    public void Push(Vector2 vector)
    {
        transform.position += (Vector3)vector;
    }

    void Update() {
        //Check for cage
        Collider2D cageCheck = Physics2D.OverlapCircle(transform.position, 0.25f);
        if(cageCheck && cageCheck.TryGetComponent(out Cage cage))
            cage.Unlock();
    }
}
