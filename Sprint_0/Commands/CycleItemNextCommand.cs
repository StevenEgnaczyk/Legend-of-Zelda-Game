using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class CycleItemNextCommand : ICommand
{
	public Item itemPlayer;

	public CycleItemNextCommand(Item item)
	{
		itemPlayer = item;
	}

	public void Execute()
	{
		itemPlayer.Next();
    }
}