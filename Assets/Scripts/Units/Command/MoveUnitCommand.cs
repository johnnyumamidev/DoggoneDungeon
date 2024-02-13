using UnityEngine;

public class MoveUnitCommand : ICommand
{
    IUnit unit;
    Vector2 input;
    Vector2 previousPosition;
    Transform unitTransform;
    public MoveUnitCommand(IUnit _unit, Transform _unitTransform, Vector2 _input) {
        unit = _unit;
        input = _input;
        unitTransform = _unitTransform;
        previousPosition = unitTransform.position;
    }
    public void Execute()
    {
        unit.Move(input, false);
    }

    public void Undo()
    {
        Vector3 undoDirection = (Vector3)previousPosition - unitTransform.position; 
        unit.Move(undoDirection, true);
    }

}
