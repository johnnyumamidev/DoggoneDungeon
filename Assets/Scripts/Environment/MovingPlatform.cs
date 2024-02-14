using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] TimeIncrementManager timeIncrementManager;
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    int currentWaypointIndex = 0;
    int tickCounter = 0;
    public int ticksRequired = 3;
    public float platformSpeed = 10;
    [SerializeField] bool active = false;
    // Start is called before the first frame update
    void OnEnable()
    {
        timeIncrementManager.OnTick += UpdateWaypoint;
    }
    void OnDisable() {
        timeIncrementManager.OnTick -= UpdateWaypoint;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 currentWaypointPosition = waypoints[currentWaypointIndex].position;
        transform.position = 
            Vector3.Lerp(transform.position, currentWaypointPosition, platformSpeed * Time.deltaTime);
    }

    void UpdateWaypoint() {
        if(!active) return;

        tickCounter++;
        if(tickCounter <= ticksRequired) {
            return;
        }
        else {
            tickCounter = 0;
        }

        currentWaypointIndex++;
        if(currentWaypointIndex >= waypoints.Count)
            currentWaypointIndex = 0;
    }

    public void Activate(bool b) {
        active = b;
    }
}
