using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading;

public class FlameState : IItemState
{
    private Item item;

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;
    public FlameState(Item item)
    {
        this.item = item;
        currentIndex = 0;
        bufferIndex = 0;
    }
    public void Draw(SpriteBatch spriteBatch)
    {

            Texture2D flameTexture = Texture2DStorage.GetOldManSpriteSheet();
            Rectangle sourceRect = ItemRectStorage.getFlameSprites(currentIndex);
            item.DrawSprite(spriteBatch, flameTexture, sourceRect);

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
    public void Next()
    {
        item.state = new ArrowState(item);
    }
    public void Prev()
    {
        item.state = new RupeeState(item);
    }
}