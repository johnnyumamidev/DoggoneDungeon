using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWaitState : State
{
    public DogFollowState dogFollowState;
    public override State RunCurrentState()
    {
        return this;
    }
}
