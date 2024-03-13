using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSitCommand : ICommand
{
    Player player;
    public DogSitCommand(Player _player) {
        player = _player;
    }
    public void Execute()
    {
        player.CommandDogToSit();
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
