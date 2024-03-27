using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelNode : MonoBehaviour, IInteractable
{
    public string levelName;
    void Awake() { 
        levelName = name;
    }

    public void Interact(Transform interactor)
    {
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
