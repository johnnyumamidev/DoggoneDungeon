using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflector : MonoBehaviour, IPushable
{
    [SerializeField] Laser[] lasers;
    Vector2 reflectedLaserVector;
    [SerializeField] List<Transform> reflectionPoints = new List<Transform>();
    [SerializeField] Transform horizLaser, vertLaser;
    [SerializeField] Battery lastBatteryHit;
    [SerializeField] Reflector lastReflectorHit;
    Vector2 laserLengthStart, laserLengthEnd = Vector2.zero;
    public bool reflecting = false;
    public bool NoObstacles(Vector2 vector)
    {
        throw new System.NotImplementedException();
    }

    public void Push(Vector2 vector)
    {
        transform.position += (Vector3)vector;
    }
    
    public void ReflectLaser(Vector2 incomingVector) {
        Vector2 reflectionStartPos = Vector2.zero;
        
        foreach(Transform reflectionPoint in reflectionPoints) {
            Vector2 reflectionDirection = reflectionPoint.position - transform.position;
            int reflectLaserDot = Mathf.RoundToInt(Vector2.Dot(reflectionDirection, incomingVector));
            if(reflectLaserDot == 0) {
                reflectedLaserVector = reflectionDirection;
                laserLengthEnd = laserLengthStart + (reflectedLaserVector * 20); 

                reflectionStartPos = reflectionPoint.position;

                if(Mathf.Abs(reflectedLaserVector.x) > 0) {
                    vertLaser.gameObject.SetActive(false);
                    horizLaser.gameObject.SetActive(true);
                }
                else {
                    vertLaser.gameObject.SetActive(true);
                    horizLaser.gameObject.SetActive(false);
                }
            }
        }

        //handle reflection 
        RaycastHit2D hit = Physics2D.Raycast(reflectionStartPos, reflectedLaserVector);
        if(!hit) {
            if(lastBatteryHit != null) {
                lastBatteryHit.hitByLaser = false;
                lastBatteryHit = null;
            }
            if(lastReflectorHit != null) {
                lastReflectorHit.reflecting = false;
                lastReflectorHit = null;
            }
            return;
        }
    
        Transform t = hit.transform;
        Battery battery = null;
        Reflector reflector = null;
        
        if(t) {
            laserLengthEnd = t.position;
            battery = t.GetComponent<Battery>();
            reflector = t.GetComponent<Reflector>();
        }

        if(battery) {
            lastBatteryHit = battery;
            battery.hitByLaser = true;
        }
        else if(reflector) {
            lastReflectorHit = reflector;
            if(reflector.LaserReceived(reflectedLaserVector)) {
                reflector.ReflectLaser(reflectedLaserVector);
                reflector.reflecting = true;
            }
        }
        else {
            if(lastReflectorHit){
                lastReflectorHit.reflecting = false;
                lastReflectorHit = null;
            }
            if(lastBatteryHit) {
                lastBatteryHit.hitByLaser = false;
                lastBatteryHit = null;
            }
        }
    }

    void Start()
    {
        lasers = FindObjectsOfType<Laser>();
    }

    void Update()
    {        
        laserLengthStart = transform.position;
        if(!reflecting) {
            if(lastReflectorHit) {
                lastReflectorHit.reflecting = false;
                lastReflectorHit = null;
            }
            laserLengthEnd = laserLengthStart;
        }
        reflectedLaserVector = Vector2.zero;
        Vector2 incomingLaserVector;
        foreach(Laser laser in lasers) {
            Transform laserHit = laser.LaserRay(out incomingLaserVector); 
            if(laserHit != transform) {
                continue;
            }

            if(LaserReceived(incomingLaserVector))
                ReflectLaser(incomingLaserVector);
        }   
        
        Vector2 laserLength = laserLengthEnd - laserLengthStart;
        horizLaser.localScale = new Vector3(laserLength.magnitude, 1, 1);
        vertLaser.localScale = new Vector3(1, laserLength.magnitude, 1);
    }

    public bool LaserReceived(Vector2 incomingDirection) {
        foreach(Transform reflectionPoint in reflectionPoints) {
            Vector2 acceptedDirection = transform.position - reflectionPoint.position;
            int dot = Mathf.RoundToInt(Vector2.Dot(incomingDirection, acceptedDirection)); 
            if(dot == 1) {
                return true;
            }
        }
        return false;
    }

    public void CancelReflection() {
        lastReflectorHit.reflecting = false;
        reflecting = false;
    }
}
