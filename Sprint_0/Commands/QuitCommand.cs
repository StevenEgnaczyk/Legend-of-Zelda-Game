using Microsoft.Xna.Framework.Graphics;
using System;

public class QuitCommand : ICommand
{
	public QuitCommand()
	{
	}

	public void drawSprite(SpriteBatch spriteBatch)
	{
		throw new NotImplementedException();
	}

	public void QuitProgram()
	{
		Environment.Exit(0);
	}
}
