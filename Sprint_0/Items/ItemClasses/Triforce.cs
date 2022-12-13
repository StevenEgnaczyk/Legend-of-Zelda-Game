using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Triforce : IItem
{
    //item properties
    private float xPos;
    private float yPos;
    private int Width = 48;
    private int Height = 48;

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;

    private ItemManager man;

    public Triforce(ItemManager manager, float xPosition, float yPosition)
    {
        this.xPos = ((GlobalVariables.BLOCK_SIZE - this.Width) / 2) + xPosition + 32;
        this.yPos = ((GlobalVariables.BLOCK_SIZE - this.Height) / 2) + yPosition + 32;
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
        Texture2D triforce = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getTriforceSprites(currentIndex);
        Rectangle destRect = new Rectangle((int)this.xPos, (int)this.yPos, this.Width, this.Height);
        Update();
        if(currentIndex % 2 == 0)
        {
            spriteBatch.Draw(triforce, destRect, sourceRect, Color.White);
        }
        else
        {
            spriteBatch.Draw(triforce, destRect, sourceRect, Color.LightSkyBlue);
        }
        

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