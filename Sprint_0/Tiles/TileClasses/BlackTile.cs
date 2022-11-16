using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading;

public class BlackTile : ITile
{
    private int xPosition;
    private int yPosition;

    private int width;
    private int height;

    private bool isPushable;
    private bool isWalkable;
    private bool isTeleport;

    public BlackTile(int xPos, int yPos)
    {
        this.xPosition = xPos;
        this.yPosition = yPos;

        this.width = 64;
        this.height = 64;

        this.isPushable = false;
        this.isWalkable = true;
        this.isTeleport = false;


    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D tile = Texture2DStorage.GetDungeonTileset();
        Rectangle sourceRect = RoomRectStorage.getBlockRect(7);
        Rectangle destRect = new Rectangle(xPosition, yPosition, Texture2DStorage.BLOCK_WIDTH, Texture2DStorage.BLOCK_HEIGHT);
        spriteBatch.Draw(tile, destRect, sourceRect, Color.White);
    }

    /* Getters for x,y positons as well as width/height */
    public int getXPos()
    {
        return xPosition;
    }

    public int getYPos()
    {
        return yPosition;
    }

    public int getWidth()
    {
        return width;
    }

    public int getHeight()
    {
        return height;
    }

    /* Boolean getters for the tiles main characteristics */
    public bool Pushable()
    {
        return isPushable;
    }

    public bool Walkable()
    {
        return isWalkable;
    }

    public bool Teleporter()
    {
        return isTeleport;
    }

    /* Setters for the tiles x and y positions */
    public void setXPos(int x)
    {
        this.xPosition = x;
    }
    public void setYPos(int y)
    {
        this.yPosition = y;
    }

}