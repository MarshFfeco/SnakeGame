using Godot;
using System;

public partial class ColissionPlayer : Area2D
{
    public PackedScene body = GD.Load<PackedScene>("res://Player/Body.tscn");
    public Global bodyVariables;
    public Node2D scene;

    public override void _Ready()
    {
        bodyVariables = (Global)GetNode("/root/Global");
        scene = GetTree().Root.GetNode<Node2D>("Map1");
    }
	public void _on_area_entered(Area2D body)
    {
       MakeBody();
    }

    public void MakeBody() 
    {
        Node2D instance = body.Instantiate() as Node2D;

        scene.CallDeferred("add_child", instance);

        if(bodyVariables.LengthBody > 0) {
            float pX = bodyVariables.Bodys[^bodyVariables.LengthBody].Position.X;
            float pY = bodyVariables.Bodys[^bodyVariables.LengthBody].Position.Y;

            instance.Position = new Vector2(pX, pY);
        } else {
            instance.Position = new Vector2(Position.X, Position.Y);
        }

		bodyVariables.LengthBody++;

        bodyVariables.Bodys[^bodyVariables.LengthBody] = instance;
    }
}
