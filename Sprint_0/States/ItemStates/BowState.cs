using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class BowState : IItemState
{
    private Item item;

    private static List<Rectangle> itemSprites = new List<Rectangle>()
    {
        new Rectangle(144, 0, 8, 16)
    };
    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 10;

    public BowState(Item item)
    {
        this.item = item;
        currentIndex = 0;
    }

    public void Next()
    {
        item.state = new HeartState(item);
    }

    public void Prev()
    {
        item.state = new WoodenBoomerangState(item);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D items = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = itemSprites[currentIndex];
        item.DrawSprite(spriteBatch, items, sourceRect);

    }
    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}