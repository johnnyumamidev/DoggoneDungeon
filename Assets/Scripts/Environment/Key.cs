using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IPushable
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] TileData tileData;
    void Start() {
        if(tileData == null) {
            tileData = FindObjectOfType<TileData>();
        }
        levelManager = FindObjectOfType<LevelManager>();
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
            Debug.Log("unlock cage, save doggy!");
            levelManager.GoToLevelSelectScreen();
            PlayerProgress.Instance.OnLevelCompleted();
        }
    }
}
