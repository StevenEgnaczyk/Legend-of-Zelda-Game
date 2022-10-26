using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class UsePrimaryWeaponCommand : ICommand
{
	public Link linkPlayer;

	public UsePrimaryWeaponCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		linkPlayer.UsePrimaryWeapon();
    }
}