using Godot;
using System;

public class Main : Node
{
    [Export]
    private PackedScene knifePrefab;

    private Position2D minX;
    private Position2D maxX;

    public override void _Ready()
    {
        minX = GetNode<Position2D>("MinX");
        maxX = GetNode<Position2D>("MaxX");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void _OnTimerTimeout()
    {
        Knife knife = knifePrefab.Instance() as Knife;
        float x = (float)GD.RandRange(minX.GetPosition().x, maxX.GetPosition().x);

        knife.Position = new Vector2(x, minX.GetPosition().y);
        AddChild(knife);
    }
}
