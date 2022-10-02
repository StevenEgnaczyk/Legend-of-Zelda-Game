using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class UseBowCommand : ICommand
{
	public Link linkPlayer;

	public UseBowCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		linkPlayer.UseBow();
    }
}