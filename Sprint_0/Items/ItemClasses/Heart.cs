using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Heart : IItem
{

    private int xPos;
    private int yPos;
    private int Width = 16;
    private int Height = 16;

    private int[] bufferInts;
    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;
    


    public Heart(int xPosition, int yPosition)
    {
        this.xPos = xPosition;
        this.yPos = yPosition;
        currentIndex = 0;
        bufferIndex = 0;
        bufferInts = new int[3] {currentIndex, bufferIndex, bufferMax};
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D heart = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getHeartSprites(currentIndex);
        Rectangle destRect = new Rectangle(this.xPos, this.yPos, this.Width, this.Height);
        spriteBatch.Draw(heart, sourceRect, destRect, Color.White);
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
       /*
        bufferInts = Buffer.itemBuffer(bufferInts);
       */
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