using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class CycleItemPrevCommand : ICommand
{
	public Item itemPlayer;

	public CycleItemPrevCommand(Item item)
	{
		itemPlayer = item;
	}

	public void Execute()
	{
		itemPlayer.Prev();
    }
}