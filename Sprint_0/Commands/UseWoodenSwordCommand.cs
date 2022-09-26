using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class UseWoodenSwordCommand : ICommand
{
	public Link linkPlayer;

	public UseWoodenSwordCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		linkPlayer.UseWoodenSword();
    }
}