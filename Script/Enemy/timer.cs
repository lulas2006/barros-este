using Godot;
using System;

public partial class timer : Timer
{
	private void _on_timeout()
	{
		Random rnd = new Random();
		var p = GetTree().GetFirstNodeInGroup("res://enemy.tscn");
		//var l = p.GetNode<CharacterBody2D>();
		//l.Position = new Vector2(rnd.Next(10, 100), rnd.Next(10, 100));
		AddChild(p);
	}
}



