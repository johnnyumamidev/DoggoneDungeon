using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelNode : MonoBehaviour, IInteractable
{
    public string levelName;
    public event Action<LevelNode, bool> OnPlayerDetected;
    public bool unlocked = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color lockedColor, unlockedColor;
    void Awake() { 
        levelName = name;
    }
    void Update()
    {
        if(DetectPlayer())
            OnPlayerDetected?.Invoke(this, unlocked);

        if(unlocked) {
            spriteRenderer.color = unlockedColor;
        }
        else {
            spriteRenderer.color = lockedColor;
        }
    }

    Player DetectPlayer()
    {
        Collider2D collider = Physics2D.OverlapCircle((Vector2)transform.position + Vector2.down, 0.25f);
        if (collider)
        {
            Player player = collider.GetComponent<Player>();
            return player;
        }
        return null;
    }

    public void UnlockLevel() {
        unlocked = true;
    }

    public void Interact()
    {
        if(!unlocked) 
            return;
            
        string scene = "PuzzleLevel";
        GameStateManager.Instance.TransitionTo(scene);
        GameStateManager.Instance.SetCurrentLevel(this);
        PlayerProgress.Instance.OnLevelEntered();
    }

    public void Cancel()
    {
        throw new NotImplementedException();
    }
}
