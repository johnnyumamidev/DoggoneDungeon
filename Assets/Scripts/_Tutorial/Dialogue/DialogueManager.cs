using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] UnityEvent<int> OnDialogueStart;
    [SerializeField] UnityEvent OnDialogueEnd;
    [SerializeField] UnityEvent OnSceneEnd;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TMP_Text textBox;

    [SerializeField] List<SceneSO> dialogueScenes = new();    
    SceneSO currentScene;
    [SerializeField] int currentSceneIndex;

    [SerializeField] int currentLineIndex;
    [SerializeField] float delayTime = 2f;
    [SerializeField] CinemachineVirtualCamera speakerVirtualCam;

    void Awake() {
        dialogueBox.SetActive(false);
    }
    void Start()
    {
        Invoke("StartDialogue", delayTime);
    }
    void Update() {
        currentScene = dialogueScenes[currentSceneIndex];
        textBox.text = currentScene.dialogueLines[currentLineIndex];
        if(GameStateManager.Instance.dialogueActive) {
            // speakerVirtualCam.Priority = dialogueScenes[currentSceneIndex].cameraPriority;
            if(Input.GetKeyDown(KeyCode.Space))
                StartCoroutine(TransitionToNextLine());
        }
        else {
            // speakerVirtualCam.Priority = 0;
        }

    }
    IEnumerator TransitionToNextLine() {
        OnDialogueEnd?.Invoke();
        dialogueBox.SetActive(false);

        yield return new WaitForSeconds(0.7f);

        if(currentLineIndex < currentScene.dialogueLines.Count - 1) {
            currentLineIndex++;
            StartDialogue();
        }
        else {
            OnSceneEnd?.Invoke();
            GameStateManager.Instance.dialogueActive = false;
            dialogueBox.SetActive(false);
            if(currentSceneIndex < dialogueScenes.Count-1) {
                currentSceneIndex++;
                currentLineIndex = 0;
            }
            else {            
                Debug.Log("end of tutorial");
            }
            //transition to next set of dialogue and begin gameplay
        }
    }
    public void StartDialogue() {
        GameStateManager.Instance.dialogueActive = true;
        OnDialogueStart?.Invoke(currentLineIndex);
        dialogueBox.SetActive(true);
    }
}