using Microsoft.Xna.Framework.Graphics;
using System;

public class ResetCommand : ICommand
{
    public ITile tilePlayer;
    public IItem itemPlayer;
    public Link linkPlayer;
    //add npc

	public ResetCommand(Link link)
	{
        linkPlayer = link;
	}

	public void Execute()
	{
        linkPlayer.reset();
	}
}