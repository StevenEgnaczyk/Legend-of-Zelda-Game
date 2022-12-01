using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class TurnPlayerLeftCommand : ICommand
{
	public Link linkPlayer;

	public TurnPlayerLeftCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		//change link state to left
		linkPlayer.TurnLeft();
    }
}