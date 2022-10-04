using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Tile
{
    public ITileState state;
    public SpriteBatch _spriteBatch;
    public float xPos, yPos;
    public int current = 5;

    public Tile()
    {
        state = new Tile1State(this);

        xPos = 350;
        yPos = 150;
    }
    public void Next()
    {
        state.Next();
        //state.Update();
    }

    public void Prev()
    {
        state.Prev();
        //state.Update();
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        state.Draw(_spriteBatch);
    }

    public void DrawSprite(SpriteBatch _spriteBatch, Texture2D sprite, Rectangle sourceRect)
    {
        Rectangle destinationRect = new Rectangle((int)xPos, (int)yPos, sourceRect.Width * 2, sourceRect.Height * 2);
        _spriteBatch.Draw(sprite, destinationRect, Color.White);
    }

}