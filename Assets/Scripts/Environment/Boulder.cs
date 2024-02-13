using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour, IPushable, ITrigger
{
    [SerializeField] TileData tileData;
    void Start() {
        if(tileData == null) tileData = FindObjectOfType<TileData>();
    }
    public void Push(Vector2 input)
    {
        if(tileData.ValidTile(transform.position + (Vector3)input)) {
            transform.position += (Vector3)input;
        }
    }
}
