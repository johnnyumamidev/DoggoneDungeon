using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
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
            tutorialTasksCompleted++;
        }
    }

    public void Continue() {
        currentTask.TaskEvent();
    }

    IEnumerator DelayBeforeNextTask(float delay) {
        yield return new WaitForSeconds(delay);
        dialogueManager.StartDialogue();
    }
}