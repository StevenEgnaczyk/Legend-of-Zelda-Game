using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class Item
{
    public IItemState state;
    public ItemSprite sprite;

    public float xPos, yPos;

    public SpriteBatch _spriteBatch;

    public int itemSpeed = 3;

    public Item()
    {

        state = new Item1State(this);

        xPos = 300;
        yPos = 300;
    }

    public void Next()
    {
        state.Next();
        state.Update();
    }

    public void Prev()
    {
        state.Prev();
        state.Update();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        state.Draw(_spriteBatch);
    }

    public void DrawSprite(SpriteBatch _spriteBatch, Texture2D itemSprite, Rectangle sourceRect)
    {
        Rectangle destinationRect = new Rectangle((int)xPos, (int)yPos, sourceRect.Width * 4, sourceRect.Height * 4);
        _spriteBatch.Draw(itemSprite, destinationRect, Color.White);
    }


    // Draw and other methods omitted
}