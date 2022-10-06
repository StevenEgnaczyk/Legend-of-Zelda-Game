using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class UseBowCommand : ICommand
{
	public Link linkPlayer;
	private String arrowType;

	public UseBowCommand(Link link, String arrowType)
	{
		linkPlayer = link;
		this.arrowType = arrowType;
	}

	public void Execute()
	{
		linkPlayer.UseBow(arrowType);
    }
}