using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class DaCoin : IItem
{
    //item properties
    private int xPos;
    private int yPos;
    private int Width = 48;
    private int Height = 48;

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;

    private ItemManager man;

    public DaCoin(ItemManager manager, int xPosition, int yPosition)
    {
        this.xPos = xPosition + 8;
        this.yPos = yPosition + 8;
        currentIndex = 0;
        bufferIndex = 0;
        man = manager;
        man.addItem(this);
    }

    public void delete()
    {
        this.man.removeItem(this);
    }

    //draw method for item
    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D rupee = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getDaCoinSourceRect();
        Rectangle destRect = new Rectangle(this.xPos, this.yPos, this.Width, this.Height);
        spriteBatch.Draw(rupee, destRect, sourceRect, Color.White);

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

    public int getX()
    {
        return this.xPos;
    }

    public int getY()
    {
        return this.yPos;
    }

    // update for animation
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