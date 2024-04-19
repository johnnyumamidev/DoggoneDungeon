using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class CutsceneController : MonoBehaviour
{
    [SerializeField] CanvasGroup overlay;
    [SerializeField] float fadeTime;
    
    public void Start(){
        FadeOut();
    }
    public void FadeOut() {
        overlay.LeanAlpha(0.1f, fadeTime);
    }
}
