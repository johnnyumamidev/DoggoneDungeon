using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] UnityEvent OnTaskCompleted;
    [SerializeField] DialogueManager dialogueManager;
    TutorialTask[] tutorialTasks;
    TutorialTask currentTask;
    [SerializeField] int tutorialTasksCompleted = 0;
    void OnEnable()
    {
        tutorialTasks = GetComponentsInChildren<TutorialTask>();
        currentTask = tutorialTasks[0];
    }

    void Update()
    {
        if(tutorialTasksCompleted >= tutorialTasks.Length) {
            Debug.Log("tutorial complete!");
            return;
        }
        currentTask = tutorialTasks[tutorialTasksCompleted];
       
        if(currentTask.taskComplete) {
            OnTaskCompleted?.Invoke();
            GameStateManager.Instance.gamePaused = true;
            tutorialTasksCompleted++;
        }
    }

    public void Continue() {
        GameStateManager.Instance.gamePaused = false;
    }
}
