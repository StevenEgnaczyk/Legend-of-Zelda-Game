using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class DynamicTilesCommandPrev : ICommand
{
    public Tile tilePlayer;
    public DynamicTilesCommandPrev(Tile _tile)
	{
        tilePlayer = _tile;
	}
    public  void Execute()
    {
        tilePlayer.Prev();
    }
}