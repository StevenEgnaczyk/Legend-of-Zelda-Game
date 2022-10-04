using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class UseFireCommand : ICommand
{
	public Link linkPlayer;

	public UseFireCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		linkPlayer.UseFire();
    }
}