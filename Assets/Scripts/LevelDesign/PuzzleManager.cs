using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PuzzleManager : MonoBehaviour
{
    public float incrementLength = 0.5f;
    [SerializeField] List<Transform> tickers = new List<Transform>();
    void OnEnable() {
        StartCoroutine(IncrementTime());
    }
    void Start() {
        UserInput userInput = FindObjectOfType<UserInput>();
        userInput.GetPlayer();
    }
    IEnumerator IncrementTime() {
        float timer = 0;
        while(timer < incrementLength) {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        NotifyTickers();
        StartCoroutine(IncrementTime());
    }

    void NotifyTickers() {
        foreach(Transform ticker in tickers) {
            ticker.GetComponent<ITicker>().Tick();
        }
    }
}
