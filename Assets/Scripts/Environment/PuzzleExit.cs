using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleExit : MonoBehaviour, IInteractable
{
    public void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        // if(interactor.TryGetComponent(out Player player)) {
        //     if(player.dogFollower || PlayerProgress.Instance.completedPuzzles.Contains(GameStateManager.Instance.currentLevelSceneName)) {
        //         PlayerProgress.Instance.OnLevelCompleted(GameStateManager.Instance.currentLevelSceneName);
        //         Debug.Log("dog rescued, exit level");
        //     }
        //     else {
        //         Debug.Log("dog not rescued yet!");
        //     }

        //     GameStateManager.Instance.TransitionTo("LevelSelect");
        // }
    }
}
