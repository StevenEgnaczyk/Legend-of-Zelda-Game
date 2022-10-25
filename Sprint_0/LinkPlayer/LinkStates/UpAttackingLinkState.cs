using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class UpAttackingLinkState : ILinkState
{
    private Link link;
    private int currentIndex;

    private String weapon;

    private int bufferIndex;
    private int bufferMax = 5;

    public UpAttackingLinkState(Link link, string weapon)
    {
        this.link = link;
        this.weapon = weapon;
        bufferIndex = 0;
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
        link.state = new DownMovingLinkState(link);
    }

    public void UseWoodenSword()
    {
        link.state = new UpAttackingLinkState(link, "Wooden");
    }

    public void UseSwordBeam()
    {
        link.state = new UpAttackingLinkState(link, "Beam");
    }

    public void Die()
    {
        link.state = new DamagedLinkState(link);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (this.weapon == "Wooden")
        {
            Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
            Rectangle sourceRect = LinkRectStorage.getUpWoodenLinkSprites(currentIndex);
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, -sourceRect.Height);
        }
        else if (this.weapon == "Beam")
        {
            Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
            Rectangle sourceRect = LinkRectStorage.getUpWoodenLinkSprites(currentIndex);
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, -sourceRect.Height);
        }
    }

    public void Update()
    {
        bufferIndex++;

        if (bufferIndex == bufferMax)
        {
            bufferIndex = 0;
            currentIndex++;
            if (currentIndex == 4)
            {
                link.state = new UpMovingLinkState(link);
                currentIndex = 0;
            }
        }
    }

    public void DrawAttackingLink(SpriteBatch spriteBatch)
    {
        throw new NotImplementedException();
    }
}