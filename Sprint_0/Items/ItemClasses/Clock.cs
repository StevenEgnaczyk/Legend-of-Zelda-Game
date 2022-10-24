using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Clock : IItem
{

    private int xPos;
    private int yPos;
    private int Width = 16;
    private int Height = 16;
    public Clock(int xPosition, int yPosition)
    {
        this.xPos = xPosition;
        this.yPos = yPosition;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D clock = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getClockSprite();
        Rectangle destRect = new Rectangle(this.xPos, this.yPos, this.Width, this.Height);
        spriteBatch.Draw(clock, sourceRect, destRect, Color.White);

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