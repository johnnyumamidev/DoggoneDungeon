using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IPushable
{
    [SerializeField] TileData tileData;
    void Start() {
        if(tileData == null) {
            tileData = FindObjectOfType<TileData>();
        }
    }
    public bool NoObstacles(Vector2 vector)
    {
        throw new System.NotImplementedException();
    }

    public void Push(Vector2 vector)
    {
        if(tileData.ValidTile(transform.position + (Vector3)vector))
            transform.position += (Vector3)vector;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.TryGetComponent(out CageBlock cage)) {
            GameStateManager.Instance.TransitionTo("LevelSelect");
            PlayerProgress.Instance.OnLevelCompleted();
        }
    }
}
