using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    [SerializeField] TimeIncrementManager timeIncrementManager;
    bool b = false;
    bool c = false;
    void OnEnable() {
        timeIncrementManager.OnTick += Test;
    }
    void OnDisable() {
        timeIncrementManager.OnTick -= Test;
    }
    public void Test() {
        b = !b;
        if(b)
            transform.localScale = new Vector3(0.5f, 0.5f, 0);
        else {
            transform.localScale = new Vector3(1,1,1);
        }
    }

    public void Test2(bool t) {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        c = t;
        if(c)
            spriteRenderer.color = Color.red;
        else {
            spriteRenderer.color = Color.blue;
        }
    }
}
