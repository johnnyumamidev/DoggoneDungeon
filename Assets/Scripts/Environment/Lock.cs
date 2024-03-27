using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lock : MonoBehaviour
{
    [SerializeField] string id;
    public bool unlocked;
    void Start() {
       
    }
    public void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
    }
    void Update() {
        if(unlocked)
            GetComponent<SpriteRenderer>().color = Color.red;
    }
}
