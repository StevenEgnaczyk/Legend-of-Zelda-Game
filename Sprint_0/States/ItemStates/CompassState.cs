using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class CompassState : IItemState
{
    private Item item;
    private static List<Rectangle> itemSprites = new List<Rectangle>()
    {
        new Rectangle(258, 1, 11, 12)
    };
    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 10;

    public CompassState(Item item)
    {
        this.item = item;
        currentIndex = 0;
    }

    public void Next()
    {
       item.state = new MapState(item);       
    }

    public void Prev()
    {
        item.state = new ClockState(item);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D item1 = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = itemSprites[currentIndex];
        item.DrawSprite(spriteBatch, item1, sourceRect);

    }
    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}