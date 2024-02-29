using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WorldMapManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;
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

    void Update()
    {
        bool hide = true;
        float camSize = worldCamSize;
        Biome currentBiome = biomes[currentBiomeIndex].GetComponent<Biome>();
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

        if(currentView == MapView.World && Input.GetKeyDown(KeyCode.Space))
            EnterBiome(currentBiome);
        else if(currentView == MapView.Biome && Input.GetKeyDown(KeyCode.B)) {
            ExitBiome(currentBiome);
        }

        if(currentView == MapView.World)
            displayText.text = biomes[currentBiomeIndex].name;
        else {
            displayText.text = " ";
        }
    }

    void HandleMoveBetweenBiomes(float value) {
        if(value < 0) {
            //go up levels
            if(currentBiomeIndex > 0 )
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
    void EnterBiome(Biome currentBiome) {
        currentView = MapView.Biome;
        currentBiome.OpenBiome(player);
    }
    void ExitBiome(Biome currentBiome) {
        currentView = MapView.World;
        currentBiome.CloseBiome();
    }
    public void UnlockBiome(GameObject biome) {
        if(!biomes.Contains(biome)) {
            biomes.Add(biome);
            Biome _biome = biome.GetComponent<Biome>();
            _biome.unlocked = true;
        }
    }
}
