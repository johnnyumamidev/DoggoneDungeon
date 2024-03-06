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
    [SerializeField] List<GameObject> floors = new List<GameObject>();
    [SerializeField] int currentFloor = 0;
    [SerializeField] List<Transform> levelNodesParents = new List<Transform>();
    [SerializeField] List<LevelNode> levelNodes = new List<LevelNode>();
    
    void Awake() {
        if(player == null) 
            player = FindObjectOfType<Player>();
        if(userInput == null) 
            userInput = FindObjectOfType<UserInput>();
    }

    void Start() {
        userInput.GetPlayer();
        foreach(Transform levelNodesParent in levelNodesParents) {
            foreach(Transform node in levelNodesParent) {
                levelNodes.Add(node.GetComponent<LevelNode>());
            }
        }
        foreach(LevelNode node in levelNodes) {
            node.OnPlayerDetected += EnterLevel;
        }
        
        int index = PlayerProgress.Instance.levelsCompleted;
        for(int i = 0; i <= index; i++) {
            if(index > levelNodes.Count) return;
            levelNodes[i].UnlockLevel();
        }
    }
    void OnDisable() {
        foreach(LevelNode node in levelNodes) {
            node.OnPlayerDetected -= EnterLevel;
        }
    }

    void EnterLevel(LevelNode levelNode, bool unlocked) {
        if(Input.GetKeyDown(KeyCode.Space) && unlocked) {
            GameStateManager.Instance.TransitionTo(levelNode.name);
        }
    }

    void Update()
    {
        bool hide = true;
        Floor currentBiome = floors[currentFloor].GetComponent<Floor>();
        if(currentView == MapView.Biome) {
            hide = false;
        }
        else {
            HandleMoveBetweenFloors(userInput.GetMovementInput().x);
            player.transform.position = floors[currentFloor].transform.position;
        }
        world.SetActive(hide);

        if(currentView == MapView.World && Input.GetKeyDown(KeyCode.Space))
            EnterBiome(currentBiome);
        else if(currentView == MapView.Biome && Input.GetKeyDown(KeyCode.B)) {
            ExitBiome(currentBiome);
        }

        if(currentView == MapView.World)
            displayText.text = floors[currentFloor].name;
        else {
            displayText.text = " ";
        }
    }

    void HandleMoveBetweenFloors(float value) {
        if(value < 0) {
            //go up levels
            if(currentFloor > 0 )
                currentFloor--;
            else {
                currentFloor = floors.Count - 1;
            }
        }
        else if(value > 0){
            if(currentFloor < floors.Count - 1)
                currentFloor++;
            else {
                currentFloor = 0;
            }
        }
    }
    void EnterBiome(Floor currentFloor) {
        currentView = MapView.Biome;
        currentFloor.OpenBiome(player);
    }
    void ExitBiome(Floor currentFloor) {
        currentView = MapView.World;
        currentFloor.CloseBiome();
    }
    public void UnlockBiome(GameObject floor) {
        if(!floors.Contains(floor)) {
            floors.Add(floor);
            Floor _biome = floor.GetComponent<Floor>();
            _biome.unlocked = true;
        }
    }
}
