using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class UseSecondaryWeaponCommand : ICommand
{
	public Link linkPlayer;

	public UseSecondaryWeaponCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		//calls secondary weapon method for link
		linkPlayer.UseSecondaryWeapon();
    }
}