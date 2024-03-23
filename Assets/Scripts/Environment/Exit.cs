using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour, IInteractable
{
    [SerializeField] Lock[] locks;
    List<Lock> unlockedLocks = new List<Lock>();
    public void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        foreach(Lock _lock in locks) {
            if(_lock.unlocked && !unlockedLocks.Contains(_lock))
                unlockedLocks.Add(_lock);
        }
        if(unlockedLocks.Count == locks.Length)
            Debug.Log("Floor cleared, go to next floor!");
        else {
            Debug.Log("There are still locks remaining");
        }
    }

    void Update()
    {
        
    }
}
