using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class UpMovingLinkState : ILinkState
{
    private Link link;
    private static List<Rectangle> linkSprites = new List<Rectangle>()
    {
        new Rectangle(71, 11, 16, 16),
        new Rectangle(88, 11, 16, 16)
    };

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 10;

    private int woodenSwordFrames = 4;

    public UpMovingLinkState(Link link)
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
        link.state = new RightMovingLinkState(link);
    }

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

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
        Rectangle sourceRect = linkSprites[currentIndex];
        link.DrawSprite(spriteBatch, downMovingLink, sourceRect, sourceRect.Width - 16, sourceRect.Height - 16);

    }

    public void Update()
    {
    }
}