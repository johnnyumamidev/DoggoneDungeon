using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour, IPushable, ITrigger
{
    [SerializeField] TileData tileData;
    [SerializeField] LayerMask obstacle;
    void Start() {
        if(tileData == null) tileData = FindObjectOfType<TileData>();
    }
    public void Push(Vector2 input)
    {
        Vector3 target = transform.position + (Vector3)input;
        if(NoObstacles(target)) {
            transform.position += (Vector3)input;
        }
    }

    public bool NoObstacles(Vector2 target) {
        Collider2D collider = Physics2D.OverlapCircle(target, 0.25f, obstacle);
        if(collider || !tileData.ValidTile(target))
            return false;
        return true;
    }
}
