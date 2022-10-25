using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class TurnPlayerUpCommand : ICommand
{
	public Link linkPlayer;

	public TurnPlayerUpCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		linkPlayer.TurnUp();
    }
}