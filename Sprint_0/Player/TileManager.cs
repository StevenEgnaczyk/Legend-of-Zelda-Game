using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


public class TileManager
{
    public  List<Tile> tileList { get; set; }
    private static SpriteBatch sb;

    /* We only want one instance*/
    public static TileManager instance = new TileManager(sb);

    public static TileManager Instance
    {
        get
        {
            return instance;
        }
    }


    public TileManager(SpriteBatch spriteBatch)
    {
        tileList = new List<Tile>();
        sb = spriteBatch;
    }

    public void addTile(Tile tile)
    {
        tileList.Add(tile);
    }

    public void removeTile(Tile tile)
    {
        tileList.Remove(tile);
    }

    public void Draw()
    {
        /*
        foreach (Tile tile in tileList)
        {
            tile.Draw(sb);
        }
        */
    }
}