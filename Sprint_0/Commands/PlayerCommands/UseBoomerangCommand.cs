using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class UseBoomerangCommand : ICommand
{
	public Link linkPlayer;

	public UseBoomerangCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		linkPlayer.UseBoomerang();
    }
}