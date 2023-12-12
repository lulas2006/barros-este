using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	public const float Speed = 150f;

	Vector2 playerPosition;
	Vector2 mobPosition = Vector2.Zero;
	Vector2 targetPosition = Vector2.Zero;
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		mobPosition = this.Position;
		playerPosition = GetNode<CharacterBody2D>($"../Player").Position;
		targetPosition = (playerPosition - mobPosition).Normalized();

		velocity = Vector2.Zero;

		if (mobPosition.DistanceTo(playerPosition) < 100) {
			velocity = targetPosition;
		}

		velocity = velocity * Speed;
		Velocity = velocity;

		MoveAndSlide();
	}

}

