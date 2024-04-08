using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] GameObject trigger;
    [SerializeField] UnityEvent OnTriggered;
    public void OnTriggerEnter2D(Collider2D collider) {
        if(GameStateManager.Instance.dialogueActive || GameStateManager.Instance.gamePaused) {
            return;
        }

        if(collider.gameObject == trigger) {
            gameObject.SetActive(false);
            OnTriggered?.Invoke();
        }
    }
}
