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
    private static List<Rectangle> itemSprites = new List<Rectangle>()
    {
        new Rectangle(0, 0, 7, 8), new Rectangle(0, 8 ,7,8)
    };
    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;

    public HeartState(Item item)
    {
        this.item = item;
        currentIndex = 0;
        bufferIndex = 0;
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
        Rectangle sourceRect = itemSprites[currentIndex];
        item.DrawSprite(spriteBatch, items, sourceRect);

    }
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