using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpikesController : MonoBehaviour, ITicker
{
    [SerializeField] List<Transform> timedSpikesParents = new List<Transform>();
    int activeSpikesIndex = 0;
    int tickCounter;
    public int ticksRequired;
    bool reversed = false;
    public void Tick()
    {
        tickCounter++;
        if(tickCounter <= ticksRequired) {
            return;
        }
        else {
            tickCounter = 0;
        }

        if(!reversed) {
            if(activeSpikesIndex < timedSpikesParents.Count - 1)
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
                activeSpikesIndex = timedSpikesParents.Count - 1;
            }
        }
        
    }

    void Update()
    {
        ControlSpikes();
    }

    void ControlSpikes() {
        foreach(Transform timedSpikesParent in timedSpikesParents) {
            foreach (Transform child in timedSpikesParent) {
                Spikes spikes = child.GetComponent<Spikes>();
                if(timedSpikesParent == timedSpikesParents[activeSpikesIndex])
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
}
