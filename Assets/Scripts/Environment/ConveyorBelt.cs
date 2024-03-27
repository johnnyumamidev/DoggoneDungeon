using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour, ITicker
{
    [SerializeField] List<ConveyorBeltNode> conveyorBeltNodes;
    bool active = true;
    int ticks;
    public int ticksRequired = 2;
    void Awake() {
        ConveyorBeltNode[] nodes = FindObjectsOfType<ConveyorBeltNode>();
        foreach(ConveyorBeltNode node in nodes) {
            conveyorBeltNodes.Add(node);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tick()
    {
        if(!active) 
            return;

        ticks++;
        if(ticks < ticksRequired) {
            return;
        }
        ticks = 0;
        foreach(ConveyorBeltNode node in conveyorBeltNodes) {
            node.MoveTriggerTransform();
        }
    }
    public void Activate(bool b) {
        active = b;
    }
}
