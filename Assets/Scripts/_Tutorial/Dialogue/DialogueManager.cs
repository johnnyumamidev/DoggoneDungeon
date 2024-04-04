using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] UnityEvent<int> OnDialogueStart;
    [SerializeField] UnityEvent OnDialogueEnd;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TMP_Text textBox;
    
    //TODO create a scriptable object for each scene that contains a list of dialogue lines for the following scene
    int currentSceneIndex;

    [SerializeField][TextArea] List<string> dialogueLines = new();
    int currentLineIndex;
    [SerializeField] float delayTime = 2f;
    void Awake() {
        dialogueBox.SetActive(false);
    }
    void Start()
    {
        Invoke("StartDialogue", delayTime);
    }
    void Update() {
        textBox.text = dialogueLines[currentLineIndex];
        if(Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(TransitionToNextLine());
        }
    }
    IEnumerator TransitionToNextLine() {
        OnDialogueEnd?.Invoke();
        dialogueBox.SetActive(false);
        yield return new WaitForSeconds(delayTime);

        if(currentLineIndex < dialogueLines.Count - 1) {
            currentLineIndex++;
            OnDialogueStart?.Invoke(currentLineIndex);
            dialogueBox.SetActive(true);
        }
        else {
            Debug.Log("end of scene!");
            //transition to next set of dialogue and begin gameplay
        }
    }
    public void StartDialogue() {
        OnDialogueStart?.Invoke(currentLineIndex);
        dialogueBox.SetActive(true);
    }
}