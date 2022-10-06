using Microsoft.Xna.Framework.Graphics;
using System;

public class ResetCommand : ICommand
{
    public Tile tilePlayer;
    public Item itemPlayer;
    public Link linkPlayer;
    //add npc

	public ResetCommand(Link link, Item item, Tile tile)
	{
        linkPlayer = link;
        tilePlayer = tile;
        itemPlayer = item;
	}

	public void Execute()
	{
        linkPlayer.reset();
        tilePlayer.reset();
        itemPlayer.reset();	
	}
}