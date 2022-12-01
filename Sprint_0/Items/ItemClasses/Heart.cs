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
    private int Width = 24;
    private int Height = 24;

    private int[] bufferInts;
    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;

    private ItemManager man;

    public Heart(ItemManager manager, int xPosition, int yPosition)
    {
        this.xPos = xPosition;
        this.yPos = yPosition;
        currentIndex = 0;
        bufferIndex = 0;
        bufferInts = new int[3] {currentIndex, bufferIndex, bufferMax};
        man = manager;
        man.addItem(this);
    }

    public void delete()
    {
        man.itemList.Remove(this);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D heart = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getHeartSprites(currentIndex);
        Rectangle destRect = new Rectangle(this.xPos, this.yPos, this.Width, this.Height);
        Update();
        if (currentIndex % 2 == 0)
        {
            spriteBatch.Draw(heart, destRect, sourceRect, Color.White);
        }
        else
        {
            spriteBatch.Draw(heart, destRect, sourceRect, Color.Blue);
        }
        

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