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

    private Main mainScript;
	
    public override void _Ready()
    {
        idleSprite = GetNode<Sprite>("Idle");
        walkSprite = GetNode<Sprite>("Walk");

        idleAnimation = GetNode<AnimationPlayer>("IdleAnimation");
        walkAnimation = GetNode<AnimationPlayer>("WalkAnimation");

        mainScript = GetParent<Main>();
    }

    public override void _Process(float delta)
    {
        base._Process(delta);

        if (Input.IsActionPressed("left"))
        {
            Vector2 temp = Position;
            temp.x -= moveSpeed * delta;
            Position = temp;

            WalkRight(false);
        }
        else if (Input.IsActionPressed("right"))
        {
            Vector2 temp = Position;
            temp.x += moveSpeed * delta;
            Position = temp;

            WalkRight(true);
        }
        else
        {
            PlayIdle();
        }
    }

    private void WalkRight(bool isRight)
    {
        idleSprite.SetVisible(false);
        walkSprite.SetVisible(true);

        walkAnimation.Play("Walk");

        walkSprite.FlipH = !isRight;
    }

    private void PlayIdle()
    {
        idleSprite.SetVisible(true);
        walkSprite.SetVisible(false);

        idleSprite.FlipH = walkSprite.FlipH;

        idleAnimation.Play("Idle");
    }

    private void _OnCollisionEntered(Area2D area)
    {
        if (area.IsInGroup("Knife"))
        {
            mainScript.PlayerDied();
            QueueFree();
        }
    }
}
