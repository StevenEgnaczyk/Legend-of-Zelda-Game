using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Bow : IItem
{
    //item properties
    private float xPos;
    private float yPos;
    private int Width = 32;
    private int Height = 64;
    private ItemManager man;
    public Bow(ItemManager manager, int xPosition, int yPosition)
    {
        this.xPos = ((GlobalVariables.BLOCK_SIZE - this.Width) / 2) + xPosition;
        this.yPos = ((GlobalVariables.BLOCK_SIZE - this.Height) / 2) + yPosition;
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
        Texture2D bow = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getBowSprite();
        Rectangle destRect = new Rectangle((int)this.xPos, (int)this.yPos, this.Width, this.Height);
        spriteBatch.Draw(bow, destRect, sourceRect, Color.White);

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
    }
}