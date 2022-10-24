using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class KeyState : IItemState
{
    private Item item;

    public KeyState(Item item)
    {
        this.item = item;
    }

    public void Next()
    {
        item.state = new HeartContainerState(item);
    }

    public void Prev()
    {
        item.state = new MapState(item);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D items = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getKeySprite();
        item.DrawSprite(spriteBatch, items, sourceRect);

    }
    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}