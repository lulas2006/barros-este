using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	public const float Speed = 300.0f;

	public override void _PhysicsProcess(double delta)
	{
		
		MoveAndSlide();
	}
}
