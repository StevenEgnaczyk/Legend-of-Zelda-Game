using Microsoft.Xna.Framework.Graphics;
using System;

public class QuitCommand : ICommand
{

	public QuitCommand()
	{
	}

	public void Execute()
	{
		Environment.Exit(0);
	}
}
