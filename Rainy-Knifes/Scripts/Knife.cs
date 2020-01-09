using Godot;
using System;

public class Knife : Node2D
{
    [Export]
    float moveSpeed = 700f;

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        Vector2 temp = Position;
        temp.y += moveSpeed * delta; 
        Position = temp;
    }
}
