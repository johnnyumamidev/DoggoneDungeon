using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFollowState : State
{
    Dog dog;
    public DogWaitState dogWaitState;
    public override State RunCurrentState()
    {
        return this;
    }
}
