using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour, ITicker
{
    [SerializeField] List<Transform> spikesParents = new List<Transform>();
    int activeSpikesIndex = 0;
    int tickCounter;
    public int ticksRequired;
    bool reversed = false;

    #region TimedSpikesSystem
    public void Tick()
    {
        tickCounter++;
        if(tickCounter <= ticksRequired) {
            return;
        }
        else {
            tickCounter = 0;
        }

        ChangeSpikeIndex(reversed);
        ControlSpikes();
    }

    void ControlSpikes() {
        foreach(Transform spikesParent in spikesParents) {
            foreach (Transform child in spikesParent) {
                Spikes spikes = child.GetComponent<Spikes>();
                if(spikesParent == spikesParents[activeSpikesIndex])
                    spikes.Activate(false);
                else {
                    spikes.Activate(true);
                }
            }
        }
    }

    public void ReverseDirection(bool _reversed) {
        reversed = _reversed;
    }

    public void ChangeSpikeIndex(bool reversed) {
        if(!reversed) {
            if(activeSpikesIndex < spikesParents.Count - 1)
                activeSpikesIndex++;
            else {
                activeSpikesIndex = 0;
            }
        }
        else {
            if(activeSpikesIndex > 0) {
                activeSpikesIndex--;
            }
            else {
                activeSpikesIndex = spikesParents.Count - 1;
            }
        }
    }
    #endregion

    public void ActivateAllSpikes(bool b) {
        foreach(Transform parent in spikesParents) {
            foreach(Transform child in parent) {
                if(child.TryGetComponent(out Spikes spikes)) {
                    spikes.Activate(b);
                }
            }
        }
    }
}
