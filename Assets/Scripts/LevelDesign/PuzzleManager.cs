using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PuzzleManager : MonoBehaviour
{
    public float incrementLength = 0.5f;
    [SerializeField] List<ITicker> tickers;
    TileData tileData;
    [SerializeField] AudioClip musicClip;
    void OnEnable() {
        StartCoroutine(IncrementTime());
        tickers = new List<ITicker>(FindObjectsOfType<MonoBehaviour>().OfType<ITicker>());
        Debug.Log(tickers == null);
    }
    void Start() {
        AudioManager.PlayMusic(musicClip);

        UserInput userInput = FindObjectOfType<UserInput>();
        userInput.GetPlayer();
        tileData = FindObjectOfType<TileData>();
        FindObjectOfType<Player>().SetTileData(tileData);

        if(PlayerProgress.Instance.completedPuzzles.Contains(GameStateManager.Instance.currentLevelSceneName)) {
            Key key = FindObjectOfType<Key>();
            Destroy(key.gameObject);
            Dog dog = FindObjectOfType<Dog>();
            Destroy(dog.gameObject);
            Cage cage = FindObjectOfType<Cage>();
            Destroy(cage.gameObject);
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
