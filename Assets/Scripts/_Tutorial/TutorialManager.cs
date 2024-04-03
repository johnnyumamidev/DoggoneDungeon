using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TutorialManager : MonoBehaviour
{
    TutorialTask[] tutorialTasks;
    TutorialTask currentTask;
    [SerializeField] CinemachineVirtualCamera playerVirtualCam, speakerVirtualCam;
    [SerializeField] int tutorialTasksCompleted = 0;
    void OnEnable()
    {
        tutorialTasks = GetComponentsInChildren<TutorialTask>();
        currentTask = tutorialTasks[0];
    }

    void Update()
    {
        currentTask = tutorialTasks[tutorialTasksCompleted];
        if(currentTask.taskComplete) {
            tutorialTasksCompleted++;
            //Trigger next tutorial cutscene
        }
    }
}
