using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class LeftMovingLinkState : ILinkState
{
    private Link link;

    //buffer for animatoin
    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 10;

    //set defaults
    public LeftMovingLinkState(Link link)
    {
        this.link = link;
        currentIndex = 0;
    }

    //deals with animation for walking left
    public void TurnLeft()
    {
        link.xPos -= link.linkSpeed;
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

    //action methods for state change
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
    public void Die()
    {
        link.state = new DamagedLinkState(link);
    }

    public void UseWoodenSword()
    {
        link.state = new LeftAttackingLinkState(link, "Wooden");
    }

    public void UseSwordBeam()
    {
        link.state = new LeftAttackingLinkState(link, "Beam");
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
        Rectangle sourceRect = LinkRectStorage.getLeftMovingLink(currentIndex);
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
        Rectangle sourceRect = LinkRectStorage.getLeftAttackingLink(currentIndex);
        link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, sourceRect.Height - 16);
    }
}