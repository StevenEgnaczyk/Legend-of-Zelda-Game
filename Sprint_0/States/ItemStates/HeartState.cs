using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class HeartState : IItemState
{
    private Item item;

    private int[] bufferInts;
    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;
    


    public HeartState(Item item)
    {
        this.item = item;
        currentIndex = 0;
        bufferIndex = 0;
        bufferInts = new int[3] {currentIndex, bufferIndex, bufferMax};
    }

    public void Next()
    {
        item.state = new RupeeState(item);
    }

    public void Prev()
    {
        item.state = new BowState(item);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D items = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getHeartSprites(bufferInts[0]);
        item.DrawSprite(spriteBatch, items, sourceRect);

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