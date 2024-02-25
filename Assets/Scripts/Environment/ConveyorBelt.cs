using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour, ITicker
{
    [SerializeField] ConveyorBeltNode[] conveyorBeltNodes;
    void Awake() {
        conveyorBeltNodes = GetComponentsInChildren<ConveyorBeltNode>();
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
        foreach(ConveyorBeltNode node in conveyorBeltNodes) {
            node.MoveTriggerTransform();
        }
    }
}
