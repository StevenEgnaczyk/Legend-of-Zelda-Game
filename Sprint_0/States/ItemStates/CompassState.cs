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

    public CompassState(Item item)
    {
        this.item = item;
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
        Rectangle sourceRect = ItemRectStorage.getCompassSprite();
        item.DrawSprite(spriteBatch, item1, sourceRect);

    }
    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}