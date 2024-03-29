using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPushable
{
    void Push(Vector2 vector);
    bool NoObstacles(Vector2 vector);
    bool OnMovingPlatform(Vector2 vector);
}
