using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public float incrementLength = 0.5f;
    [SerializeField] List<Transform> tickers = new List<Transform>();
    TileData tileData;
    Lock _lock;
    void OnEnable() {
        StartCoroutine(IncrementTime());
    }
    void Start() {
        UserInput userInput = FindObjectOfType<UserInput>();
        userInput.GetPlayer();
        tileData = FindObjectOfType<TileData>();
        FindObjectOfType<Player>().SetTileData(tileData);
    }

    #region TimeIncrementation
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
    #endregion
}
