using Godot;
using System;

public partial class coin : Area2D
{
	AnimationPlayer animationPlayer;
	
	public delegate void CoinCollected();

	public override void _Ready()
	{
	}

	Signal coin_collected;

	public override void _Process(double delta)
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animationPlayer.Play("Coin");	
	}
	
	private void _on_body_entered(CharacterBody2D body)
	{
 		if(body.Name == "Player")
		{
			hud hud = GetTree().Root.GetNode("World").GetNode("Player").GetNode("Camera2D").GetNode<hud>("HUD");
			hud.addCoin();
			QueueFree();
		}	
	}
	
	private void _on_timer_timeout()
	{
		QueueFree();
	}
}
