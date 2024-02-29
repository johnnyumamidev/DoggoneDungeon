using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    IUnit[] units;
    UnitCommandInvoker unitCommandInvoker;
    [SerializeField] LayerMask interactableLayer;
    void Start() {
        units = FindObjectsOfType<MonoBehaviour>().OfType<IUnit>().ToArray();
        unitCommandInvoker = new UnitCommandInvoker();
    }
    void Update()
    {
        HandleGameInput();
    }

    private void HandleGameInput()
    {
        Vector2 moveVector = GetMovementInput();
        bool undo = Input.GetKeyDown(KeyCode.Z);
        bool reset = Input.GetKeyDown(KeyCode.R);

        //movement input
        if (moveVector != Vector2.zero)
        {
            foreach (IUnit unit in units)
            {
                Transform unitTransform = ((MonoBehaviour)unit).transform;

                ICommand interactCommand = new InteractCommand(unitTransform, moveVector, interactableLayer);
                unitCommandInvoker.AddCommand(interactCommand);

                ICommand pushCommand = new PushCommand(unitTransform, moveVector);
                unitCommandInvoker.AddCommand(pushCommand);

                ICommand moveCommand = new MoveUnitCommand(unit, unitTransform, moveVector);
                unitCommandInvoker.AddCommand(moveCommand);
            }
        }
        //undo input
        else if (undo)
        {
            foreach (IUnit unit in units)
            {
                unitCommandInvoker.UndoCommand(3);
            }
        }
        else if(reset) {
            //Reset level
        }
    }

    public Vector2 GetMovementInput() {
        bool h = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D);
        bool v = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S);
        if(h)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            return new Vector2(horizontal, 0);
        }
        else if(v)
        {
            float vertical = Input.GetAxisRaw("Vertical");
            return new Vector2(0, vertical);
        }
        return Vector2.zero;
    }
}