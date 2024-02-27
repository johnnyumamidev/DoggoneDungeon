using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dog : MonoBehaviour, IUnit, ITrigger
{
    public Player player;
    Vector3 targetPosition;

    public void Move(Vector2 input, bool undo)
    {
        // if(player == null) return;
        
        // Vector3 directionToPlayer = player.transform.position - transform.position; 
        // Vector3 direction = directionToPlayer;
        // if(!player.CanMove(player.transform.position + (Vector3)input))
        //     direction = Vector2.zero;
        // transform.position += direction;
        
        // if(undo) 
        //     transform.position += (Vector3)input;
    }
}
