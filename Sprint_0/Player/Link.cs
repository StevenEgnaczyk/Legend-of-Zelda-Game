using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class Link
{
    public ILinkState state;
    public LinkSprite sprite;

    public Link()
    {
        state = new RightMovingLinkState(this);
        sprite = new LinkSprite();
    }

    public void TurnLeft()
    {
        state.TurnLeft();
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
        throw new NotImplementedException();
    }

    public void move(int x, int y)
    {

    }

    public void Draw()
    {
        sprite.Draw();
    }


    // Draw and other methods omitted
}