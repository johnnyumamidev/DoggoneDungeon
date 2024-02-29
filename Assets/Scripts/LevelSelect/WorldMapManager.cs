using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldMapManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] UserInput userInput;
    public enum MapView { World, Biome }
    public MapView currentView;
    [SerializeField] GameObject world;
    [SerializeField] List<GameObject> biomes = new List<GameObject>();
    [SerializeField] int currentBiomeIndex = 0;
    [SerializeField] float worldCamSize, biomeCamSize;
    void Awake() {
        if(player == null) 
            player = FindObjectOfType<Player>();
        if(userInput == null) 
            userInput = FindObjectOfType<UserInput>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool hide = true;
        float camSize = worldCamSize;
        if(currentView == MapView.Biome) {
            hide = false;
            camSize = biomeCamSize;
        }
        else {
            HandleMoveBetweenBiomes(userInput.GetMovementInput().x);
            player.transform.position = biomes[currentBiomeIndex].transform.position;
        }
        world.SetActive(hide);
        Camera.main.orthographicSize = camSize;

        if(Input.GetKeyDown(KeyCode.Space))
            HandleSelectBiome();
    }

    void HandleMoveBetweenBiomes(float value) {
        if(value < 0) {
            //go up levels
            if(currentBiomeIndex > 0)
                currentBiomeIndex--;
            else {
                currentBiomeIndex = biomes.Count - 1;
            }
        }
        else if(value > 0){
            if(currentBiomeIndex < biomes.Count - 1)
                currentBiomeIndex++;
            else {
                currentBiomeIndex = 0;
            }
        }
    }
    void HandleSelectBiome() {
        Biome currentBiome = biomes[currentBiomeIndex].GetComponent<Biome>();
        if(currentView == MapView.Biome) {
            currentView = MapView.World;
            currentBiome.CloseBiome();
            return;
        }
        
        currentView = MapView.Biome;
        currentBiome.OpenBiome(player);
    }
    void HideBiomes(bool b) {
        foreach(GameObject biome in biomes) {
            biome.SetActive(!b);
        }
    }
}
