using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lock : MonoBehaviour, IInteractable
{
    public bool locked;

    public void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        Debug.Log("check for keys");
    }
}
