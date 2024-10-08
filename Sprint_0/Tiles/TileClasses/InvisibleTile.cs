using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

public class InvisibleTile : ITile
{
    private int xPosition;
    private int yPosition;

    private int width;
    private int height;

    private bool isPushable;
    private bool isWalkable;
    private bool isTeleport;
    private bool isLocked;

    public InvisibleTile(int xPos, int yPos)
    {
        this.xPosition = xPos;
        this.yPosition = yPos;

        this.width = 64;
        this.height = 64;

        this.isPushable = false;
        this.isWalkable = false;
        this.isTeleport = false;

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        
        Texture2D tile = Texture2DStorage.GetDungeonTileset();
        Rectangle sourceRect = RoomRectStorage.getBlockRect(0);
        Rectangle destRect = new Rectangle(xPosition, yPosition, Texture2DStorage.BLOCK_WIDTH, Texture2DStorage.BLOCK_HEIGHT);
        spriteBatch.Draw(tile, destRect, sourceRect, Color.White);
        
    }

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
    public bool Locked()
    {
        return isLocked;
    }
    public void Unlock()
    {
        isLocked = false;
    }
    public void setXPos(int x)
    {

    }
    public void setYPos(int y)
    {
        
    }
}