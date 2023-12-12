using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	public const float Speed = 150f;

	Vector2 playerPosition = Vector2.Zero;
	Vector2 mobPosition = Vector2.Zero;
	Vector2 targetPosition = Vector2.Zero;
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		mobPosition = this.Position;
		playerPosition = GetNode<CharacterBody2D>("Player").Position;
		targetPosition = (mobPosition - playerPosition).Normalized();
		Velocity = targetPosition;

		targetPosition = targetPosition * Speed;
		Velocity = velocity;
		MoveAndSlide();
	}
	
	private void _on_player_detection_body_entered(Node2D body)
	{

	}
	
	private void _on_player_detection_body_exited(Node2D body)
	{

	}
}

