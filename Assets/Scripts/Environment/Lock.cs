using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Lock : MonoBehaviour
{
    [SerializeField] TileBase cageTile;
    [SerializeField] Tilemap wallsTilemap;
    public bool locked = true;
    [SerializeField] SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForKey();
        ControlCage();
    }
    void CheckForKey() {
        Collider2D keyCheck = Physics2D.OverlapCircle((Vector2)transform.position + Vector2.down, 0.25f);
        if(keyCheck && keyCheck.TryGetComponent(out Key key)) {
            SavePuzzleProgress();
            locked = false;
            Destroy(key.gameObject);
        }
    }
    void ControlCage() {
        Vector3Int tilePosition = wallsTilemap.WorldToCell(transform.position);
        if(locked) 
            wallsTilemap.SetTile(tilePosition, cageTile);
        else {
            wallsTilemap.SetTile(tilePosition, null);
            spriteRenderer.enabled = false;
        }
    }
    void SavePuzzleProgress() {
        PlayerProgress.Instance.OnLevelCompleted(GameStateManager.Instance.currentLevelSceneName);
    }

    public void ControlLock(bool a) {
        locked = !a;
    }
}
