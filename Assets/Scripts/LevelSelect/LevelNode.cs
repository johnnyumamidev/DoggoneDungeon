using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelNode : MonoBehaviour
{
    public event Action<LevelNode> OnPlayerDetected;
    
    void Update()
    {
        if(DetectPlayer())
            OnPlayerDetected?.Invoke(this);
    }

    Player DetectPlayer()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.25f);
        if (collider)
        {
            Player player = collider.GetComponent<Player>();
            return player;
        }
        return null;
    }
}
