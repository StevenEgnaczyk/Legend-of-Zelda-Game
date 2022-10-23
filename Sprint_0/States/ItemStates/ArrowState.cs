using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class ArrowState : IItemState
{
    private Item item;

    public ArrowState(Item item)
    {
        this.item = item;
    }

    public void Next()
    {
        item.state = new BombState(item);
    }

    public void Prev()
    {
        item.state = new FlameState(item);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D item10 = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getArrowSprite();
        item.DrawSprite(spriteBatch, item10, sourceRect);

    }
    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}