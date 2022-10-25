using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class TurnPlayerRightCommand : ICommand
{
	public Link linkPlayer;

	public TurnPlayerRightCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		linkPlayer.TurnRight();
    }
}