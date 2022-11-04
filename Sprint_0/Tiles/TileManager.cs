using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


public class TileManager
{
    public  List<ITile> tileList { get; set; }
    private static SpriteBatch sb;

    /* We only want one instance*/
    public static TileManager instance = new TileManager(sb);
    private static int HUD_SIZE = 224;

    public static TileManager Instance
    {
        get
        {
            return instance;
        }
    }


    public TileManager(SpriteBatch spriteBatch)
    {
        tileList = new List<ITile>();
        sb = spriteBatch;
    }

    public void addTile(ITile tile)
    {
        tileList.Add(tile);
    }

    public void removeTile(ITile tile)
    {
        tileList.Remove(tile);
    }

    public ITile getTileByIndex(int tileIndex, int row, int col)
    {
        switch (tileIndex)
        {
            case 0:
                return(new InvisibleTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 1:
                return(new walkTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 2:
                return(new BrickTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 3:
                return(new BlueSandTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 4:
                return(new WaterTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 5:
                return(new StatueRightTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 6:
                return(new StatueLeftTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 7:
                return(new BlackTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 8:
                return(new StairTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 9:
                return(new PushTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 10:
                return (new UnlockedDoorTileLeft(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 11:
                return (new UnlockedDoorTileRight(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 12:
                return(new UndergroundTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 13:
                return(new LadderTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;
            case 14:
                return (new VerticalDoorTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;                
            default:
                return(new InvisibleTile(64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                break;

        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        
        foreach (ITile tile in tileList)
        {
            tile.Draw(spriteBatch);
        }
        
    }
}