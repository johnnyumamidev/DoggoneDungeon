using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCommandInvoker
{
    List<ICommand> commands;

    public UnitCommandInvoker() {
        commands = new List<ICommand>();
    }

    public void AddCommand(ICommand newCommand) {
        newCommand.Execute();
        commands.Add(newCommand);
    }

    public void UndoCommand(int commandsCount) {
        if(commands.Count > 0) {
            for(int i = 0; i < commandsCount; i++) {
                ICommand latestCommand = commands[^1];
                latestCommand.Undo();
                commands.Remove(latestCommand);
            }
        }
    }
}
