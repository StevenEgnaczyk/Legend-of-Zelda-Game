using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class StatueRightTile : ITile
{
    private int xPosition;
    private int yPosition;

    private int width;
    private int height;

    private bool isPushable;
    private bool isWalkable;

    public StatueRightTile(int xPos, int yPos)
    {
        this.xPosition = xPos;
        this.yPosition = yPos;

        this.width = 64;
        this.height = 64;

        this.isPushable = false;
        this.isWalkable = false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D tile = Texture2DStorage.GetDungeonTileset();
        Rectangle sourceRect = Texture2DStorage.getBlockRect(5);
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
    public void setXPos(int x)
    {

    }
    public void setYPos(int y)
    {
        
    }
}