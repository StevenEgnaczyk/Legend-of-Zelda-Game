using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class DamagedLinkState : ILinkState
{
    private Link link;
    private static List<Rectangle> linkSprites = new List<Rectangle>()
    {
        new Rectangle(214, 11, 13, 16),
        new Rectangle(231, 11, 14, 16)
    };

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;

    public DamagedLinkState(Link link)
    {
        this.link = link;
        currentIndex = 0;
    }

    public void TurnLeft()
    {
    }

    public void TurnRight()
    {
    }

    public void TurnUp()
    {
    }

    public void TurnDown()
    {
    }

    public void UseWoodenSword()
    {
    }

    public void UseSwordBeam()
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
        Rectangle sourceRect = linkSprites[currentIndex];
        link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, 0);

    }

    public void Update()
    {
        bufferIndex++;

        if (bufferIndex == bufferMax)
        {
            bufferIndex = 0;
            currentIndex++;
            if (currentIndex == 2)
            {
                link.state = new DownMovingLinkState(link);
                currentIndex = 0;
            }
        }
    }

    public void UseBoomerang()
    {
    }

    public void UseBow()
    {
    }

    public void Die()
    {
    }
}