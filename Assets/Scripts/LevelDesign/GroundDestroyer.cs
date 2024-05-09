using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundDestroyer : MonoBehaviour
{
    [SerializeField] UnityEvent OnPlayerHit;
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
        //loop through all points
        foreach(Transform point in pointsParent) {

            //check for tiles
            Vector3Int tilePosition = tileData.groundTilemap.WorldToCell(point.position);
            if(tileData.groundTilemap.HasTile(tilePosition)) {
                tileData.groundTilemap.SetTile(tilePosition, null);
            }

            //check for objects
            Collider2D _collider = Physics2D.OverlapCircle(point.position, 0.05f);
            if(_collider) {
                if(_collider.TryGetComponent(out Player player))
                    OnPlayerHit?.Invoke();
                if(_collider.TryGetComponent(out IPushable pushable)) {
                    Transform p = ((MonoBehaviour)pushable).transform;
                    Destroy(p.gameObject);
                }
            }
        }
    }
}
