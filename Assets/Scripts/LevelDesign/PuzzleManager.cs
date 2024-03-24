using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PuzzleManager : MonoBehaviour
{
    public float incrementLength = 0.5f;
    [SerializeField] List<ITicker> tickers;
    TileData tileData;
    void OnEnable() {
        StartCoroutine(IncrementTime());
        tickers = new List<ITicker>(FindObjectsOfType<MonoBehaviour>().OfType<ITicker>());
        Debug.Log(tickers == null);
    }
    void Start() {
        UserInput userInput = FindObjectOfType<UserInput>();
        userInput.GetPlayer();
        tileData = FindObjectOfType<TileData>();
        FindObjectOfType<Player>().SetTileData(tileData);

        if(PlayerProgress.Instance.completedPuzzles.Contains(GameStateManager.Instance.CurrentLevel.name)) {
            Key key = FindObjectOfType<Key>();
            Destroy(key.gameObject);
        }
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
        foreach(ITicker ticker in tickers) {
            ticker.Tick();
        }
    }
    #endregion
}
