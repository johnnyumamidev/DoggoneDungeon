using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameStateManager.Instance.TransitionTo("LevelSelect");    
        PlayerProgress.Instance.OnLevelCompleted(GameStateManager.Instance.currentLevelSceneName);
    }

    public void Cancel()
    {
        throw new System.NotImplementedException();
    }
}
