using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class Link
{
    public ILinkState state;
    public LinkSprite sprite;

    public float xPos, yPos;

    public SpriteBatch _spriteBatch;

    public int linkSpeed = 3;

    public Link()
    {

        state = new DownMovingLinkState(this);

        xPos = 100;
        yPos = 100;
    }

    public void TurnLeft()
    {
        state.TurnLeft();
        state.Update();
    }

    public void TurnRight()
    {
        state.TurnRight();
    }

    public void TurnUp()
    {
        state.TurnUp();
    }

    public void TurnDown()
    {
        state.TurnDown();
    }

    public void Update()
    {
        state.Update();
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        state.Draw(_spriteBatch);
    }

    public void DrawSprite(SpriteBatch _spriteBatch, Texture2D linkSprite, Rectangle sourceRect)
    {
        Rectangle destinationRect = new Rectangle((int)xPos, (int)yPos, sourceRect.Width * 4, sourceRect.Height * 4);
        _spriteBatch.Draw(linkSprite, destinationRect, sourceRect, Color.White);
    }

    internal void UseWoodenSword()
    {
        state.UseWoodenSword();
    }

    internal void UseSwordBeam()
    {
        //state.UseSwordBeam();
    }


    // Draw and other methods omitted
}