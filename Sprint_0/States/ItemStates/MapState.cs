using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class MapState : IItemState
{
    private Item item;

    public MapState(Item item)
    {
        this.item = item;
    }

    public void Next()
    {
        item.state = new KeyState(item);
    }

    public void Prev()
    {
        item.state = new CompassState(item);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D items = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getMapSprite();
        item.DrawSprite(spriteBatch, items, sourceRect);

    }
    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}