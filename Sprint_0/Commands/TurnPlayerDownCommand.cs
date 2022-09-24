using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class TurnPlayerDownCommand : ICommand
{
	public Link linkPlayer;

	public TurnPlayerDownCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		linkPlayer.TurnDown();
    }
}