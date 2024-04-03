using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTask : MonoBehaviour
{
    public bool taskComplete = false;

    public void CompleteTask() {
        taskComplete = true;
    }
}
