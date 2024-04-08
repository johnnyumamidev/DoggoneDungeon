using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialTask : MonoBehaviour
{
    [SerializeField] UnityEvent OnTaskCompleted;
    [SerializeField] UnityEvent OnTaskStart;

    public bool taskComplete = false;
    public float waitTimeAfterComplete;

    public void CompleteTask() {
        taskComplete = true;
        OnTaskCompleted?.Invoke();
        gameObject.SetActive(false);
    }
    public void TaskEvent() {
        OnTaskStart?.Invoke();
    }
}
