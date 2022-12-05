using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class HeartContainer : IItem
{
    //item properties
    private float xPos;
    private float yPos;
    private int Width = 24;
    private int Height = 48;

    private ItemManager man;

    public HeartContainer(ItemManager manager, int xPosition, int yPosition)
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

    //draw method for item
    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D heartContainer = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getHeartContainerSprite();
        Rectangle destRect = new Rectangle((int)this.xPos, (int)this.yPos, this.Width, this.Height);
        spriteBatch.Draw(heartContainer, destRect, sourceRect, Color.White);

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