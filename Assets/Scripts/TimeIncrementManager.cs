using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeIncrementManager : MonoBehaviour
{
    public event Action OnTick;
    public float incrementLength = 0.5f;
    void OnEnable() {
        StartCoroutine(IncrementTime());
    }
    IEnumerator IncrementTime() {
        float timer = 0;
        while(timer < incrementLength) {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        OnTick?.Invoke();
        StartCoroutine(IncrementTime());
    }
}
