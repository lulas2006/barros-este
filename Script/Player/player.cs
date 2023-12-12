using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float speed = 300f; //original 200
	
	public AnimationPlayer animationPlayer;

	public void GetInput() {
		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = inputDirection * speed;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Velocity = velocity;

		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

		//Estar parado
		if (!Input.IsAnythingPressed() && (Input.IsActionJustReleased("right") || Input.IsActionJustReleased("left") || Input.IsActionJustReleased("up") || Input.IsActionJustReleased("down"))) {
			animationPlayer.Play("Idle");
		}
	
		//Correr
		if (Input.IsActionPressed("right")) {
			animationPlayer.Play("Run");
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
		} else if(Input.IsActionPressed("left")) {
			animationPlayer.Play("Run");
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
		} else if(Input.IsActionPressed("up")) {
			animationPlayer.Play("Run");
		} else if(Input.IsActionPressed("down")) {
			animationPlayer.Play("Run");
		}

		GetInput();
		MoveAndSlide();
	}
}
