using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class DieCommand : ICommand
{
	public Link linkPlayer;

	public DieCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		linkPlayer.Die();
		AudioStorage.GetLinkDie().Play();
    }
}