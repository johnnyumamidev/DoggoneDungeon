using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    List<float> rotationAngles = new List<float> {
        0, 90, 180, -90
    };
    List<Vector2> directions = new List<Vector2> {
        Vector2.down, Vector2.right, Vector2.up, Vector2.left
    };
    [SerializeField] int rotationIndex = 0;
    int previousIndex;
    [SerializeField] Transform laserStart;
    [SerializeField] bool active = false;
    bool laserHit = false;
    RaycastHit2D[] hits;
    RaycastHit2D firstHit;
    Vector2 laserLength = Vector2.down * 20;
    public Transform LaserRay(out Vector2 direction) {
        direction = directions[rotationIndex];
        if(!active) 
            return null;

        hits = Physics2D.RaycastAll(laserStart.position, direction);
        if(hits.Length == 0)
            return null;

        for(int i = 0; i < hits.Length; i++) {
            if(hits[i].transform.TryGetComponent(out MovingPlatform movingPlatform))
                continue;
            firstHit = hits[i];
            break;
        }

        laserHit = firstHit;
        if(laserHit)
            return firstHit.transform;
        return null;
    }

    public void Activate(ISwitch _switch) {
        active = _switch.IsTriggered();
    }
    void Update() {
        if(laserHit) {
            Vector2 laserVector = firstHit.point - (Vector2)laserStart.position;  
            laserStart.localScale = new Vector3(1, laserVector.magnitude, 1);
        }
        else {
            laserStart.localScale = new Vector3(1, laserLength.magnitude, 1);
        }

        rotationIndex = Mathf.Clamp(rotationIndex, 0, rotationAngles.Count-1);
        transform.rotation = Quaternion.Euler(0, 0, rotationAngles[rotationIndex]);
    }
}
