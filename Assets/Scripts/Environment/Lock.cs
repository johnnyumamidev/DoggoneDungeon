using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lock : MonoBehaviour, IInteractable
{
    [SerializeField] string id;
    public bool unlocked;
    void Start() {
        if(PlayerProgress.Instance.unlockedLocks.ContainsKey(id)) {
            unlocked = true;
        }
    }
    public void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        if(PlayerProgress.Instance.keysCollected > 0) {
            unlocked = true;
            PlayerProgress.Instance.UseKey(id, unlocked);
        }
    }
    void Update() {
        if(unlocked)
            GetComponent<SpriteRenderer>().color = Color.red;
    }
}
