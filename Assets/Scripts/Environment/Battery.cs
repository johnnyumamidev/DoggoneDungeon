using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Battery : MonoBehaviour
{
    public UnityEvent<bool> emitPower;
    [SerializeField] Laser laser;
    public enum PowerType { Normal, Reversed };
    public PowerType powerType;
    bool reversePower = false;
    bool powered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(laser.LaserRay() == transform) {
            powered = true;
            reversePower = false;
        }
        else {
            powered = false;
            reversePower = true;
        }
        if(powerType == PowerType.Normal)
            emitPower?.Invoke(powered);
        else {
            emitPower?.Invoke(reversePower);
        }
    }
}
