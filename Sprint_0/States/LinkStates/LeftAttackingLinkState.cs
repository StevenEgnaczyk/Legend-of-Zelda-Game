using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class LeftAttackingLinkState : ILinkState
{
    private Link link;

    private static List<Rectangle> woodenSwordSprites = new List<Rectangle>()
    {
        new Rectangle(354, 206, 15, 15),
        new Rectangle(325, 206, 27, 15),
        new Rectangle(301, 206, 23, 15),
        new Rectangle(281, 205, 19, 16)

    };

    private static List<Rectangle> whiteSwordSprites = new List<Rectangle>()
    {
        new Rectangle(353, 223, 15, 15),
        new Rectangle(280, 223, 19, 16),
        new Rectangle(302, 223, 21, 15),
        new Rectangle(325, 223, 26, 15)

    };

    private int currentIndex;

    private String weapon;

    private int bufferIndex;
    private int bufferMax = 5;

    public LeftAttackingLinkState(Link link, String weapon)
    {
        this.link = link;
        this.weapon = weapon;
        bufferIndex = 0;
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
        link.state = new UpMovingLinkState(link);
    }

    public void TurnDown()
    {
        link.state = new DownMovingLinkState(link);
    }

    public void UseWoodenSword()
    {
        link.state = new LeftAttackingLinkState(link, "Wooden");
    }

    public void UseSwordBeam()
    {
        link.state = new LeftAttackingLinkState(link, "Beam");
    }

    public void UseBoomerang()
    {
        link.state = new DownAttackingLinkState(link, "Boomerang");
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
            Rectangle sourceRect = woodenSwordSprites[currentIndex];
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 15 - sourceRect.Width, 0);
        }
        else if (this.weapon == "Beam")
        {
            Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
            Rectangle sourceRect = whiteSwordSprites[currentIndex];
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 15 - sourceRect.Width, 0);
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
                link.state = new LeftMovingLinkState(link);
                currentIndex = 0;
            }
        }
    }

    public void UseBow()
    {
        throw new NotImplementedException();
    }
}