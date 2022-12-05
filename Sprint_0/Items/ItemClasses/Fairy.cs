using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Fairy : IItem
{
    //item properties
    private float xPos;
    private float yPos;
    private int Width = 24;
    private int Height = 48;

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;

    private ItemManager man;

    public Fairy(ItemManager manager, int xPosition, int yPosition)
    {
        this.xPos = xPosition;
        this.yPos = yPosition;
        this.currentIndex = 0;
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
        Texture2D fairy = Texture2DStorage.GetItemSpritesheet();       
        Rectangle destRect = new Rectangle((int)this.xPos, (int)this.yPos, this.Width, this.Height);
        Update();
        Rectangle sourceRect = ItemRectStorage.getFairySprites(currentIndex);
        spriteBatch.Draw(fairy, destRect, sourceRect, Color.White);
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

    //update for animation
    public void Update()
    {
        if (currentIndex == 0)
        {
            bufferIndex++;
        }
        else
        {
            bufferIndex += 2;
        }

        if (bufferIndex == bufferMax)
        {
            bufferIndex = 0;
            currentIndex++;
            if (currentIndex == 2)
            {
                currentIndex = 0;
            }
        }
    }
}