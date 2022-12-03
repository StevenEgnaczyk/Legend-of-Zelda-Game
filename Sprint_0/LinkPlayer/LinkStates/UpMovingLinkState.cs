using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class UpMovingLinkState : ILinkState
{
    private Link link;

    //buffer for animation
    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 10;

    //set defaults
    public UpMovingLinkState(Link link)
    {
        this.link = link;
        currentIndex = 0;
    }

    //action methods for state change
    public void TurnLeft()
    {
        link.state = new LeftMovingLinkState(link);
    }

    public void TurnRight()
    {
        link.state = new RightMovingLinkState(link);
    }

    //handles animation for walking up
    public void TurnUp()
    {
        link.yPos -= link.linkSpeed;
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
        Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
        Rectangle sourceRect = LinkRectStorage.getUpMovingLink(currentIndex);
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

    public void DrawAttackingLink(SpriteBatch spriteBatch)
    {
        Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
        Rectangle sourceRect = LinkRectStorage.getUpAttackingLink(currentIndex);
        link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, sourceRect.Height - 16);
    }
}