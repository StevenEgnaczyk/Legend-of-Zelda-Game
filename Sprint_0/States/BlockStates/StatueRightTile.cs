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

    public StatueRightTile(int xPos, int yPos)
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
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
}