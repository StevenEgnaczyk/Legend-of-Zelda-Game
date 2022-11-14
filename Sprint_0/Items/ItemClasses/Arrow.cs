using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Arrow : IItem
{

    private int xPos;
    private int yPos;
    private int Width = 24;
    private int Height = 48;

    private ItemManager man;
    public Arrow(ItemManager manager, int xPosition, int yPosition)
    {
        this.xPos = xPosition;
        this.yPos = yPosition;
        man = manager;
        man.addItem(this);
    }

    public void delete()
    {
        throw new NotImplementedException();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D arrow = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getUpArrowSprite();
        Rectangle destRect = new Rectangle(this.xPos, this.yPos, this.Width, this.Height);
        spriteBatch.Draw(arrow, destRect, sourceRect, Color.White);

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