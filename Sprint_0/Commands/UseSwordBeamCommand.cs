using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class UseSwordBeamCommand : ICommand
{
	public Link linkPlayer;

	public UseSwordBeamCommand(Link link)
	{
		linkPlayer = link;
	}

	public void Execute()
	{
		linkPlayer.UseSwordBeam();
    }
}