using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Key : IItem
{

    private int xPos;
    private int yPos;
    private int Width = 16;
    private int Height = 16;
    public Key(int xPosition, int yPosition)
    {
        this.xPos = xPosition;
        this.yPos = yPosition;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D key = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getKeySprite();
        Rectangle destRect = new Rectangle(this.xPos, this.yPos, this.Width, this.Height);
        spriteBatch.Draw(key, sourceRect, destRect, Color.White);

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
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}