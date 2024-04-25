using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance { get; private set; }
    [SerializeField] Camera mainCam;
    [SerializeField] Transform[] rooms;
    Transform currentRoom;
    int roomIndex = 0;
    [SerializeField] float speed;
    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeRoom(roomIndex);   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(currentRoom.position.x, currentRoom.position.y, -10);
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, target, speed * Time.deltaTime);
    }

    public void ChangeRoom(int roomNumber) {
        roomIndex = roomNumber;
        currentRoom = rooms[roomIndex];

        if(currentRoom.TryGetComponent(out ScrollingRoom scrollingRoom)) {
            scrollingRoom.StartScroll();
        }
    }
}
