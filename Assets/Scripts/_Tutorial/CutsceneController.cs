using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] GameObject cutsceneGameObject;
    [SerializeField] GameObject[] shots;
    [SerializeField] CanvasGroup overlay;
    [SerializeField] float fadeTime;
    int shotIndex;

    void Start()
    {
        cutsceneGameObject.SetActive(false);
        foreach(GameObject shot in shots) {
            shot.SetActive(false);
        }
    }
    public void DisableImage() {
        if(cutsceneGameObject != null)
            cutsceneGameObject.SetActive(false);
    }
    public void EnableImage(int index) {
        shotIndex = index;
        for(int i = 0; i < shots.Length; i++) {
            if(i == shotIndex)
                shots[i].SetActive(true);
            else {
                shots[i].SetActive(false);
            }
        }
        if(cutsceneGameObject != null)
            cutsceneGameObject.SetActive(true);
    }
    public void HideCutscene() {
        overlay.LeanAlpha(0, fadeTime);
        if(cutsceneGameObject != null)
            cutsceneGameObject.SetActive(false);
        cutsceneGameObject = null;
    }
}
