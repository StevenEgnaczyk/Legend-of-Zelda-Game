using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class Item
{
    public IItemState state;
    public ItemSprite sprite;

    public int xPos, yPos;

    public SpriteBatch _spriteBatch;

    //  public int itemSpeed = 3;
    public double scale = 3;

    public Item(ItemManager man)
    {

        state = new MapState(this);

        xPos = 850;
        yPos = 225;

        man.addItem(state);
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
        //implement
    }

    public void reset()
    {
        state = new CompassState(this);
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        state.Draw(_spriteBatch);
        state.Update();
    }

    public void DrawSprite(SpriteBatch _spriteBatch, Texture2D itemSprite, Rectangle sourceRect)
    {
        Rectangle destinationRect = new Rectangle((int)xPos, (int)yPos, (int)((double)sourceRect.Width * scale), (int)((double)sourceRect.Height * scale));
        _spriteBatch.Draw(itemSprite, destinationRect, sourceRect, Color.White);
    }

    public void remove(ItemManager man)
    {
        man.removeItem(state);
    }

    // Draw and other methods omitted
}