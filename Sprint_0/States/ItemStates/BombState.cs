using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class BombState : IItemState
{
    private Item item;
    public BombState(Item item)
    {
        this.item = item;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D bombTexture = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = new Rectangle(136, 0, 8, 14);
        item.DrawSprite(spriteBatch, bombTexture, sourceRect);
    }

    public void Next()
    {
        item.state = new FairyState(item);
    }

    public void Prev()
    {
        item.state = new ArrowState(item);
    }

    public void Update()
    {
        //jiububiubiubi
    }
}