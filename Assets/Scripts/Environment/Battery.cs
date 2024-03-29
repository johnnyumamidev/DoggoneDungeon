using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Battery : MonoBehaviour, ISwitch
{
    public UnityEvent<ISwitch> emitPower;
    [SerializeField] Laser[] lasers;
    public enum PowerType { Normal, Reversed };
    public PowerType powerType;
    [SerializeField] bool powered = false;
    public bool hitByLaser = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    void Start()
    {
        lasers = FindObjectsOfType<Laser>();
    }
    // Update is called once per frame
    void Update()
    {
        powered = CheckForPower();
        spriteRenderer.color = Color.blue;
        if(powerType == PowerType.Reversed) {
            powered = !CheckForPower();
            spriteRenderer.color = Color.red;
        }

        emitPower?.Invoke(this);
    }

    bool CheckForPower() {
        foreach(Laser laser in lasers) {
            if(laser.LaserRay(out Vector2 laserDirection) == transform) {
                return true;
            }
        }

        return false | hitByLaser;
    }

    public bool IsTriggered()
    {
        return powered;
    }
}
