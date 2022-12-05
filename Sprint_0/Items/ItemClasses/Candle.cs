using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading;

public class Candle : IItem
{
    //item properties
    private int xPos;
    private int yPos;
    private int Width = 24;
    private int Height = 48;

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;

    private ItemManager man;
    public Candle(ItemManager manager, int xPosition, int yPosition)
    {
        this.xPos = xPosition;
        this.yPos = yPosition;
        currentIndex = 0;
        bufferIndex = 0;

        man = manager;

        man.addItem(this);
    }

    //draw method for item
    public void Draw(SpriteBatch spriteBatch)
    {

        Texture2D flame = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getCandleSprite();
        Rectangle destRect = new Rectangle(this.xPos + 20, this.yPos + 8, this.Width, this.Height);
        spriteBatch.Draw(flame, destRect, sourceRect, Color.White);

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

    public void delete()
    {
        man.removeItem(this);
        
    }
}