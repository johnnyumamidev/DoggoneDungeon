using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] GameObject[] shots;
    int shotIndex;
    void Start()
    {
        image.gameObject.SetActive(false);
        foreach(GameObject shot in shots) {
            shot.SetActive(false);
        }
    }
    public void DisableImage() {
        image.gameObject.SetActive(false);
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
        image.gameObject.SetActive(true);
    }
}
