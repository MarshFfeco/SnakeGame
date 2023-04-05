using Godot;
using System;

public partial class Player : CharacterBody2D
{
	Global bodyVariables;
	private float Speed {get; set;} = 16.0f;
	[Export]
    private float DelayTime {get; set;} = 0.6f;
    private float DelayCount {get; set;} = 0;
    private Vector2 Direction {get; set;} = Vector2.Up;
	private float RotationPlayer {get; set;} = 0f;

	private int plusVelocity = 0;
	public int PlusVelocity {
		get { return plusVelocity; } 
		set { plusVelocity = value < 2 ? value : 10000; } 
		}

    private void GetInput() 
    {
        Vector2 inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        
        if(inputDirection == Vector2.Up && RotationDegrees != 180) {
			RotationPlayer = 0;
            Direction = inputDirection;
        } else if(inputDirection == Vector2.Down && RotationDegrees != 0) {
			RotationPlayer = 180;
            Direction = inputDirection;
        } else if(inputDirection == Vector2.Left && RotationDegrees != 90) {
			RotationPlayer = 270;
            Direction = inputDirection;
        } else if(inputDirection == Vector2.Right && RotationDegrees != 270) {
			RotationPlayer = 90;
            Direction = inputDirection;
        }
    }
    private void  MovementPlayer() 
    {
		RotationDegrees = RotationPlayer;
        Position += Direction * Speed;
    }
	private void  MovementBody() 
    {
		if(bodyVariables.CurrentBody > bodyVariables.LengthBody) {
			bodyVariables.CurrentBody = 1;
		}

        bodyVariables.Bodys[^bodyVariables.CurrentBody].Position = new Vector2(Position.X, Position.Y);
		bodyVariables.CurrentBody++;
    }

	public override void _Ready()
	{
		bodyVariables = (Global)GetNode("/root/Global");
		RotationDegrees = 0;
	}
    public override void _PhysicsProcess(double delta) {
		GetInput();

		DelayCount += (float)delta;

		if(DelayCount >= DelayTime) {
			if(bodyVariables.LengthBody > PlusVelocity) {
				PlusVelocity++;
				float dimi = (float)bodyVariables.LengthBody / 10;

				DelayTime -= dimi;
				GD.Print(dimi);
			}

			DelayCount = 0;
			if(bodyVariables.LengthBody > 0) {
				MovementBody();
			}
			MovementPlayer();
		}
	}
}
