using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Map : IItem
{

    private int xPos;
    private int yPos;
    private int Width = 32;
    private int Height = 64;

    public Map(int xPosition, int yPosition)
    {
        this.xPos = xPosition;
        this.yPos = yPosition;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D map = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getMapSprite();
        Rectangle destRect = new Rectangle(this.xPos, this.yPos, this.Width, this.Height);
        spriteBatch.Draw(map, destRect, sourceRect, Color.White);

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