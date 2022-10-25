using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class RightMovingLinkState : ILinkState
{
    private Link link;

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 10;

    public RightMovingLinkState(Link link)
    {
        this.link = link;
        currentIndex = 0;
    }

    public void TurnLeft()
    {
        link.state = new LeftMovingLinkState(link);
    }

    public void TurnRight()
    {
        link.xPos += link.linkSpeed;
        bufferIndex++;
        if (bufferIndex == bufferMax)
        {
            currentIndex++;
            bufferIndex = 0;
            if (currentIndex == 2)
            {
                currentIndex = 0;
            }
        }
    }

    public void TurnUp()
    {
        link.state = new UpMovingLinkState(link);
    }

    public void TurnDown()
    {
        link.state = new DownMovingLinkState(link);
    }

    public void Die()
    {
        link.state = new DamagedLinkState(link);
    }
    public void UseWoodenSword()
    {
        link.state = new RightAttackingLinkState (link, "Wooden");
    }

    public void UseSwordBeam()
    {
        link.state = new RightAttackingLinkState(link, "Beam");
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
        Rectangle sourceRect = LinkRectStorage.getRightMovingLink(currentIndex);
        link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, 0);

    }

    public void Update()
    {
    }

    public void UseBoomerang()
    {
        throw new NotImplementedException();
    }

    public void UseBow()
    {
        throw new NotImplementedException();
    }

    public void DrawAttacker(SpriteBatch spriteBatch)
    {
        Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
        Rectangle sourceRect = LinkRectStorage.getRightAttackingLink(currentIndex);
        link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, sourceRect.Height - 16);
    }
}