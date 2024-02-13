using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface IUnit
{
   void Move(Vector2 vector, bool undo);
}
