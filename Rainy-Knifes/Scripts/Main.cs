using Godot;
using System;

public class Main : Node
{
    [Export]
    private PackedScene knifePrefab;

    private Position2D minX;
    private Position2D maxX;

    private Timer restartTimer;

    public override void _Ready()
    {
        minX = GetNode<Position2D>("MinX");
        maxX = GetNode<Position2D>("MaxX");

        restartTimer = GetNode<Timer>("RestartTimer");
        restartTimer.Connect("timeout", this, "_OnRestartGame");
        restartTimer.WaitTime = 2f;
        restartTimer.OneShot = true;
    }

    private void _OnTimerTimeout()
    {
        Knife knife = knifePrefab.Instance() as Knife;
        float x = (float)GD.RandRange(minX.GetPosition().x, maxX.GetPosition().x);

        knife.Position = new Vector2(x, minX.GetPosition().y);
        AddChild(knife);
    }

    private void _OnRestartGame()
    {
        GetTree().ReloadCurrentScene();
    }

    public void PlayerDied()
    {
        restartTimer.Start();
    }
}
