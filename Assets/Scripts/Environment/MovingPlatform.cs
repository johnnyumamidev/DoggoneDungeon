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
    Laser[] lasers;
    Collider2D platformCollider;
    void Awake() {
        lasers = FindObjectsOfType<Laser>();
        platformCollider = GetComponent<Collider2D>();
    }
    void Update()
    {
        currentWaypointPosition = waypoints[currentWaypointIndex].position;
        transform.position = 
            Vector3.Lerp(transform.position, currentWaypointPosition, platformSpeed * Time.deltaTime);

        platformCollider.enabled = true;
        foreach(Laser laser in lasers) {
            if(laser.LaserRay(out Vector2 direction) == transform)
                platformCollider.enabled = false;
        }
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

    public void Activate(ISwitch _switch) {
        active = _switch.IsTriggered();
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
