using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    Lock[] locks;
    List<Lock> unlockedLocks = new List<Lock>();
    // Start is called before the first frame update
    void Start()
    {
        locks = FindObjectsOfType<Lock>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Lock _lock in locks) {
            if(!_lock.locked && !unlockedLocks.Contains(_lock))
                unlockedLocks.Add(_lock);
        }

        Collider2D playerCheck = Physics2D.OverlapCircle(transform.position, 0.25f);
        if(playerCheck && playerCheck.TryGetComponent(out Player player))
        {
            if(Input.GetKeyDown(KeyCode.Space))
                ExitLevel();
        }
    }

    private void ExitLevel()
    {
        if (locks.Length == unlockedLocks.Count)
        {
            Debug.Log("level completed!");
            GameStateManager.Instance.TransitionTo("LevelSelect");
        }
    }
}
