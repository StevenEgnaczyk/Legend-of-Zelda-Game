using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Item13State : IItemState
{
    private Item item;
    private static List<Rectangle> itemSprites = new List<Rectangle>()
    {
        new Rectangle(1, 11, 16, 16),
        new Rectangle(19, 11, 16, 16)
    };
    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 10;

    public Item13State(Item item)
    {
        this.item = item;
        currentIndex = 0;
    }

    public void Next()
    {
        item.state = new Item1State(item);
    }

    public void Prev()
    {
        item.state = new Item12State(item);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D item13 = Texture2DStorage.GetItem13Sprite();
        Rectangle sourceRect = itemSprites[currentIndex];
        item.DrawSprite(spriteBatch, item13, sourceRect);

    }
    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}