using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour
{
    [SerializeField] TileData tileData;
    [SerializeField] GameObject biomeMap;
    [SerializeField] Transform start;
    public bool unlocked = false;

    [SerializeField] SpriteRenderer spriteRenderer;
    Color biomeColor;
    void Start() {
        biomeColor = spriteRenderer.color;
    }
    void Update() {
        if(unlocked)
            spriteRenderer.color = biomeColor;
        else {
            spriteRenderer.color = Color.red;
        }
    }
    public void OpenBiome(Player player) {
        Debug.Log("open " + name);
        biomeMap.SetActive(true);
        player.SetTileData(tileData);
        player.transform.position = start.position;
    }

    public void CloseBiome() {
        biomeMap.SetActive(false);
    }
}
