using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflector : MonoBehaviour, IPushable, IInteractable
{
    [SerializeField] Laser[] lasers;
    public Vector2 laserDirection;
    Vector2 reflectedLaserVector;
    [SerializeField] List<Transform> reflectionPoints = new List<Transform>();
    bool reflect = false;
    [SerializeField] Transform laserTransform;
    Battery lastBatteryHit;
    Vector2 laserLengthStart, laserLengthEnd = Vector2.zero;
    public bool NoObstacles(Vector2 vector)
    {
        throw new System.NotImplementedException();
    }

    public void Push(Vector2 vector)
    {
        transform.position += (Vector3)vector;
    }
    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void Cancel()
    {
        throw new System.NotImplementedException();
    }
    
    public void Reflect() {
        Vector2 reflectionStartPos = Vector2.zero;
        foreach(Transform reflectionPoint in reflectionPoints) {
            Vector2 reflectionDirection = reflectionPoint.position - transform.position;
            int receiveLaserDot = Mathf.RoundToInt(Vector2.Dot(-laserDirection, reflectionDirection)); 
            int reflectLaserDot = Mathf.RoundToInt(Vector2.Dot(reflectionDirection, laserDirection));
            
            if(reflectLaserDot == 0) {
                reflectedLaserVector = reflectionDirection;
                laserLengthEnd = laserLengthStart + (reflectionDirection * 20); 

                reflectionStartPos = reflectionPoint.position;

                laserTransform.position = laserLengthStart;
            }
        }

        //handle reflection 
        RaycastHit2D[] hitsInReflectionPath = Physics2D.RaycastAll(reflectionStartPos, reflectedLaserVector);
        if(hitsInReflectionPath.Length == 0) {
            if(lastBatteryHit != null) {
                lastBatteryHit.hitByLaser = false;
                lastBatteryHit = null;
            }
            return;
        }
        
        for(int i = 0; i < hitsInReflectionPath.Length; i++) {
            RaycastHit2D hit = hitsInReflectionPath[i];
            Transform t = hit.transform;
            laserLengthEnd = t.position;

            if(t.TryGetComponent(out Reflector reflector)) {
                reflector.laserDirection = reflectedLaserVector;
                reflector.Reflect();

                if(lastBatteryHit != null) {
                    lastBatteryHit.hitByLaser = false;
                    lastBatteryHit = null;
                }
                break;
            }

            if(t.TryGetComponent(out Battery battery)) {
                lastBatteryHit = battery;
                battery.hitByLaser = true;
                break;
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
        laserLengthEnd = transform.position;
        foreach(Laser laser in lasers) {
            Transform laserHit = laser.LaserRay(out laserDirection); 
            if(laserHit == transform) {
                Reflect();
            }
        }   
        Vector2 laserLength = laserLengthEnd - laserLengthStart;
        laserTransform.localScale = new Vector3(laserLength.magnitude, 1, 1);
    }
    void OnDrawGizmos() {
        Gizmos.DrawRay(transform.position, reflectedLaserVector * 20);
    }
}
