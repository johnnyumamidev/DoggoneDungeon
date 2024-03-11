using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public float incrementLength = 0.5f;
    [SerializeField] List<Transform> tickers = new List<Transform>();
    TileData tileData;
    Key key;
    bool levelCompleted = false;
    void OnEnable() {
        StartCoroutine(IncrementTime());
    }
    void Start() {
        UserInput userInput = FindObjectOfType<UserInput>();
        userInput.GetPlayer();
        tileData = FindObjectOfType<TileData>();
        FindObjectOfType<Player>().SetTileData(tileData);

        key = FindObjectOfType<Key>();
        key.OnCageUnlocked += SavePuzzleProgress;
    }
    void OnDisable() {
        key.OnCageUnlocked -= SavePuzzleProgress;
    }

    void SavePuzzleProgress() {
        PlayerProgress.Instance.OnLevelCompleted(GameStateManager.Instance.currentLevelSceneName);
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
