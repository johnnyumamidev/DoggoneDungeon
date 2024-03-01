using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.25f);
        if(collider) {
            CageBlock cage = collider.GetComponent<CageBlock>();
            if(cage != null) {
                Debug.Log("saved the dog!");
            }
        }
    }
}
