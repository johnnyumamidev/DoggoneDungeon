using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour
{
    public enum Direction { Up, Down };
    public Direction direction;
    DungeonMapManager dungeonMapManager;
    void Awake()
    {
        if(dungeonMapManager == null)
            dungeonMapManager = FindObjectOfType<DungeonMapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.25f);
        if(collider) {
            Player player = collider.GetComponent<Player>();
            if(player != null) {
                int i = 1;
                if(direction == Direction.Down)
                    i = -1;
                dungeonMapManager.TravelBetweenFloors(i);
            }
        }
    }
}
