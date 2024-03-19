using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Battery : MonoBehaviour
{
    public UnityEvent<bool> emitPower;
    [SerializeField] Laser[] lasers;
    public enum PowerType { Normal, Reversed };
    public PowerType powerType;
    bool powered = false;
    public bool hitByLaser = false;
    void Start()
    {
        lasers = FindObjectsOfType<Laser>();
    }
    // Update is called once per frame
    void Update()
    {
        powered = CheckForPower();

        if(powerType == PowerType.Normal)
            emitPower?.Invoke(powered);
        else {
            emitPower?.Invoke(!powered);
        }
    }

    bool CheckForPower() {
        foreach(Laser laser in lasers) {
            if(laser.LaserRay(out Vector2 laserDirection) == transform) {
                return true;
            }
        }

        return false | hitByLaser;
    }
}
