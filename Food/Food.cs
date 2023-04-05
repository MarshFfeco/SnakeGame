using Godot;
using System;

public partial class Food : Area2D
{
	public PackedScene Player = GD.Load<PackedScene>("res://Player/Player.tscn");
	private Area2D PlayerArea;

	public void _on_area_entered(Area2D area)
	{
		QueueFree();
	}
}
