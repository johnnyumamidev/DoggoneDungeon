using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Battery : MonoBehaviour
{
    public UnityEvent<bool> emitPower;
    [SerializeField] Laser laser;
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
        }
        else {
            powered = false;
        }

        emitPower?.Invoke(powered);
    }
}
