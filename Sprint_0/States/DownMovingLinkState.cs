using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class DownMovingLinkState : ILinkState
{
    private Link link;

    public DownMovingLinkState(Link link)
    {
        this.link = link;
        // construct goomba's sprite here too
    }

    public void TurnLeft()
    {
        link.state = new LeftMovingLinkState(link);
    }

    public void TurnRight()
    {
        link.state = new RightMovingLinkState(link);
    }

    public void TurnUp()
    {
        link.state = new UpMovingLinkState(link);
    }

    public void TurnDown()
    {
        throw new NotImplementedException();
    }

    public void Die()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
        Rectangle sourceRect = new Rectangle(1, 11, 16, 16);
        link.DrawSprite(spriteBatch, downMovingLink, sourceRect);

    }
    public void Update()
    {
        link.move(0,0);
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}