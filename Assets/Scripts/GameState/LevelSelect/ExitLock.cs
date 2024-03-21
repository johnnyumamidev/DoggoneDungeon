using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLock : MonoBehaviour, IInteractable
{
    public void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        Debug.Log("checking for key");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
