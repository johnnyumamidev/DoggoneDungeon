using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DungeonMapManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] Player player;
    [SerializeField] UserInput userInput;
    [SerializeField] List<Floor> floors = new List<Floor>();
    [SerializeField] int currentFloorIndex = 0;
    [SerializeField] Floor currentFloor;
    
    void Awake() {
        if(player == null) 
            player = FindObjectOfType<Player>();
        if(userInput == null) 
            userInput = FindObjectOfType<UserInput>();
    }
    void Start() {
        userInput.GetPlayer();
        LoadCurrentFloor();
    }
    void LoadCurrentFloor() {
        if(!PlayerProgress.Instance.gameStarted)
            currentFloorIndex = 0;
        else {
            currentFloorIndex = PlayerProgress.Instance.currentFloorIndex;
        }

        currentFloor = floors[currentFloorIndex];
        currentFloor.EnterFloor(player);
    }
    public void TravelBetweenFloors(int direction) {
        currentFloor.ExitFloor();
        currentFloorIndex += direction;
        PlayerProgress.Instance.OnFloorCompleted(currentFloorIndex);

        currentFloor = floors[currentFloorIndex];
        currentFloor.EnterFloor(player);
    }
}   