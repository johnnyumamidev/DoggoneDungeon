using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] Image cutsceneImage;
    [SerializeField] GameObject[] shots;
    [SerializeField] GameObject overlay;
    int shotIndex;
    void Start()
    {
        cutsceneImage.gameObject.SetActive(false);
        foreach(GameObject shot in shots) {
            shot.SetActive(false);
        }
    }
    public void DisableImage() {
        cutsceneImage.gameObject.SetActive(false);
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
        cutsceneImage.gameObject.SetActive(true);
    }
    public void HideCutscene() {
        overlay.SetActive(false);
        cutsceneImage.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
