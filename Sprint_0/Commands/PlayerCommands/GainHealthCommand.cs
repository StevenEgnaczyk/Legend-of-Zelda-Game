using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class GainHealthCommand : ICommand
{
	public Link linkPlayer;

	public GainHealthCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		//calls gainHealth method for link
		linkPlayer.gainHealth();
    }
}