using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class UserInput : MonoBehaviour
{
    Player player;
    UnitCommandInvoker unitCommandInvoker;
    [SerializeField] LayerMask interactableLayer;
    public event Action OnPause;
    void Start() {
        unitCommandInvoker = new UnitCommandInvoker();
    }
    void Update()
    {
        if(!GameStateManager.Instance.gamePaused)
            HandleGameInput();
        
        HandlePauseInput();
    }
    public void GetPlayer() {
        if(player == null)
            player = FindObjectOfType<Player>();
    }
    private void HandleGameInput()
    {
        Vector2 moveVector = GetMovementInput();
        bool undo = Input.GetKeyDown(KeyCode.Z);
        bool reset = Input.GetKeyDown(KeyCode.R);
        bool confirm = Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space);
        bool dogSit = Input.GetKeyDown(KeyCode.E);
        //movement input
        if (moveVector != Vector2.zero)
        {
            Transform unitTransform = player.transform;

            ICommand interactCommand = new InteractCommand(unitTransform, moveVector, interactableLayer);
            unitCommandInvoker.AddCommand(interactCommand);

            ICommand pushCommand = new PushCommand(unitTransform, moveVector);
            unitCommandInvoker.AddCommand(pushCommand);

            ICommand moveCommand = new MoveUnitCommand(player, unitTransform, moveVector);
            unitCommandInvoker.AddCommand(moveCommand);
        }
        //undo input
        else if (undo)
        {
            unitCommandInvoker.UndoCommand(3);
        }
        else if(reset) {
            //Reset level
        }
        else if(confirm) {
            
        }
        else if(dogSit) {
            if(!player.dogFollower)
                return; 
                
            ICommand dogSitCommand = new DogSitCommand(player);
            unitCommandInvoker.AddCommand(dogSitCommand);
        }
    }

    public Vector2 GetMovementInput() {
        if(GameStateManager.Instance.gamePaused)
            return Vector2.zero;
        bool h = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D);
        bool v = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W);

        if(h) {
            return new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }
        if(v) {
            return new Vector2(0, Input.GetAxisRaw("Vertical"));
        }

        return Vector2.zero;
    }
    void HandlePauseInput() {
        bool pause = Input.GetKeyDown(KeyCode.Escape);
        if(pause) {
            OnPause?.Invoke();
        }
    }
}