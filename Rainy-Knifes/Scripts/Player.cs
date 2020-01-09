using Godot;
using System;

public class Player : Node2D
{
	private Sprite idleSprite;
	private Sprite walkSprite;

    private AnimationPlayer idleAnimation;
    private AnimationPlayer walkAnimation;

    [Export]
    float moveSpeed = 500f;
	
    public override void _Ready()
    {
        idleSprite = GetNode<Sprite>("Idle");
        walkSprite = GetNode<Sprite>("Walk");

        idleAnimation = GetNode<AnimationPlayer>("IdleAnimation");
        walkAnimation = GetNode<AnimationPlayer>("WalkAnimation");
    }

    public override void _Process(float delta)
    {
        base._Process(delta);

        if (Input.IsActionPressed("left"))
        {
            Vector2 temp = Position;
            temp.x -= moveSpeed * delta;
            Position = temp;
        }
        else if (Input.IsActionPressed("right"))
        {
            Vector2 temp = Position;
            temp.x += moveSpeed * delta;
            Position = temp;
        }
    }
}
