using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class DownAttackingLinkState : ILinkState
{
    private Link link;
    private static List<Rectangle> woodenSwordSprites = new List<Rectangle>()
    {
        new Rectangle(1, 47, 16, 15),
        new Rectangle(18, 47, 16, 27),
        new Rectangle(35, 47, 15, 23),
        new Rectangle(53, 47, 13, 19)
    };

    private static List<Rectangle> whiteSwordSprites = new List<Rectangle>()
    {
        new Rectangle(94, 47, 16, 15),
        new Rectangle(111, 47, 16, 27),
        new Rectangle(128, 47, 15, 23),
        new Rectangle(146, 47, 13, 19)
    };

    String weapon;

    private int currentIndex;

    public DownAttackingLinkState(Link link, String weapon)
    {
        this.link = link;
        this.weapon = weapon;
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
        link.state = new DownAttackingLinkState(link, "Wooden");
    }

    public void UseSwordBeam()
    {
        link.state = new DownAttackingLinkState(link, "Beam");
    }

    public void Die()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (this.weapon == "Wooden")
        {
            Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
            Rectangle sourceRect = woodenSwordSprites[currentIndex];
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, sourceRect.Width, sourceRect.Height);
        } else if (this.weapon == "Beam")
        {
            Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
            Rectangle sourceRect = whiteSwordSprites[currentIndex];
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, sourceRect.Width, sourceRect.Height);
        }

    }

    public void Update()
    {
        currentIndex++;
        if (currentIndex == 4)
        {
            link.state = new DownMovingLinkState(link);
            currentIndex = 0;
        }
    }
}