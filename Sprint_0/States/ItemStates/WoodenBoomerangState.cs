using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class WoodenBoomerangState : IItemState
{
    private Item item;

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;

    public WoodenBoomerangState(Item item)
    {
        this.item = item;
        currentIndex = 0;
        bufferIndex = 0;
    }

    public void Next()
    {
        item.state = new BowState(item);
    }

    public void Prev()
    {
        item.state = new HeartContainerState(item);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D items = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getWoodenBoomerangSprites(currentIndex);
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
            if (currentIndex == 4)
            {
                currentIndex = 0;
            }
        }
    }
}