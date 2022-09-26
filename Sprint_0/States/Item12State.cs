using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Item12State : IItemState
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

    public Item12State(Item item)
    {
        this.item = item;
        currentIndex = 0;
    }

    public void Next()
    {
        item.state = new Item13State(item);
    }

    public void Prev()
    {
        item.state = new Item11State(item);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D item12 = Texture2DStorage.GetItem12Sprite();
        Rectangle sourceRect = itemSprites[currentIndex];
        item.DrawSprite(spriteBatch, item12, sourceRect);

    }
    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}