using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, ITicker
{
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    int currentWaypointIndex = 0;
    Vector3 currentWaypointPosition;
    int tickCounter = 0;
    public int ticksRequired = 3;
    public float platformSpeed = 10;
    [SerializeField] bool active = false;
    void Update()
    {
        currentWaypointPosition = waypoints[currentWaypointIndex].position;
        transform.position = 
            Vector3.Lerp(transform.position, currentWaypointPosition, platformSpeed * Time.deltaTime);
    }

    public void UpdateWaypoint() {
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

    public bool AtWayPoint() {
        if(Vector2.Distance(transform.position, currentWaypointPosition) < 0.05f)
            return true;
        else {
            return false;
        }
    }

    public void Tick()
    {
        UpdateWaypoint();
    }

    public void ChangeWaypoint(int i) {
        currentWaypointIndex = i;
    }
}
