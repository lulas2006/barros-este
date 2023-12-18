using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	public const float Speed = 200f;

	Vector2 playerPosition;
	Vector2 mobPosition = Vector2.Zero;
	Vector2 targetPosition = Vector2.Zero;
	
	public AnimationPlayer animationPlayer;
	
	public override void _PhysicsProcess(double delta)
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		
		Vector2 velocity = Velocity;
		mobPosition = this.Position;
		playerPosition = GetNode<CharacterBody2D>($"../Player").Position;
		targetPosition = (playerPosition - mobPosition).Normalized();

		velocity = Vector2.Zero;

		if (mobPosition.DistanceTo(playerPosition) < 200) {
			velocity = targetPosition;
			animationPlayer.Play("Run");
			if(velocity.X < 0) {
				animationPlayer.Play("Run");
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
			} else if (velocity.X > 0) {
				animationPlayer.Play("Run");
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
			}
		} else {
			animationPlayer.Play("Idle");
		}

		velocity = velocity * Speed;
		Velocity = velocity;

		MoveAndSlide();
	}

	public void Enemy() {

	}

}

