using Microsoft.Xna.Framework.Graphics;
using System;

public class SetDeadPlayerSpriteCommand : ICommand
{

	public SetDeadPlayerSpriteCommand(Game1 game)
	{
		myGame = game;
	}

	public void Execute()
	{

		//Change links state to dead
		myGame.setSprite(new DeadPlayerSprite());
	}
}