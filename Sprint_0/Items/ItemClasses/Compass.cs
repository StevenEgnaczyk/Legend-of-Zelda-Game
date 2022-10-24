using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Compass : IItem
{

    private int xPos;
    private int yPos;
    private int Width = 16;
    private int Height = 16;
    public Compass()
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D item1 = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getCompassSprite();
        //item.DrawSprite(spriteBatch, item1, sourceRect);

    }

    public int getHeight()
    {
        return this.Height;
    }

    public int getWidth()
    {
        return this.Width;
    }

    public int getX()
    {
        return this.xPos;
    }

    public int getY()
    {
        return this.yPos;
    }
    public void Update()
    {
    }
}