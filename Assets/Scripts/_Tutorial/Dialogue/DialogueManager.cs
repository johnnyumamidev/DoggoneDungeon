using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TMP_Text textBox;
    [SerializeField][TextArea] List<string> testList = new();
    int dialogueIndex;
    void Start()
    {
        dialogueBox.SetActive(false);
    }
    void Update()
    {
        
    }
    public void StartDialogue() {
        dialogueBox.SetActive(true);
        GameStateManager.Instance.dialogueActive = true;
    }
}