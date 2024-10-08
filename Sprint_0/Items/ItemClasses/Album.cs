using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Album : IItem
{
    //item properties
    private float xPos;
    private float yPos;
    private int Width = 24;
    private int Height = 48;

    private ItemManager man;
    public Album(ItemManager manager, float xPosition, float yPosition)
    {
        this.xPos = xPosition;
        this.yPos = yPosition;
        man = manager;
        man.addItem(this);
    }

    public void delete()
    {
        man.removeItem(this);
    }

    //draw method for item
    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D key = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getAlbumSourceRect();
        Rectangle destRect = new Rectangle((int)this.xPos, (int)this.yPos, this.Width, this.Height);
        spriteBatch.Draw(key, destRect, sourceRect, Color.White);

    }

    //get classes for the item
    public int getHeight()
    {
        return this.Height;
    }

    public int getWidth()
    {
        return this.Width;
    }

    public float getX()
    {
        return this.xPos;
    }

    public float getY()
    {
        return this.yPos;
    }
    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}