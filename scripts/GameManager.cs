using Godot;
using System;

public class GameManager : Node
{
    [Inject] private Player _player;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._Ready();
        this.ResolveDependencies();
        
        GD.Print($"The player name is {_player.GetName()}");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
