using Godot;
using System;

public partial class Global : Node
{
	public Node2D[] Bodys = new Node2D[10];
	public int CurrentBody {get; set;} = 1;
	public int LengthBody {get; set;} = 0;
}
