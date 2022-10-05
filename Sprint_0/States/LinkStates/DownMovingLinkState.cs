using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;

public class DownMovingLinkState : ILinkState
{
    private Link link;

    private static List<Rectangle> linkSprites = new List<Rectangle>()
    {
        new Rectangle(1, 11, 16, 16),
        new Rectangle(19, 11, 16, 16)
    };

    private static List<Rectangle> attackingLinkSprites = new List<Rectangle>()
    {
        new Rectangle(94, 47, 16, 15),
        new Rectangle(94, 47, 16, 15),
        new Rectangle(94, 47, 16, 15),
        new Rectangle(94, 47, 16, 15)
    };

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 10;

    public DownMovingLinkState(Link link)
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
        link.state = new UpMovingLinkState(link);
    }

    public void UseWoodenSword()
    {
        link.state = new DownAttackingLinkState(link, "Wooden");
    }

    public void UseSwordBeam()
    {
        link.state = new DownAttackingLinkState(link, "Beam");
    }

    public void UseBoomerang()
    {
        link.state = new DownAttackingLinkState(link, "Boomerang");
    }

    public void UseBow()
    {
        link.state = new DownAttackingLinkState(link, "Bow");
    }

    public void TurnDown()
    {
        link.yPos+= link.linkSpeed;

        bufferIndex++;
        if (bufferIndex == bufferMax) {
            currentIndex++;
            bufferIndex = 0;
            if (currentIndex == 2)
            {
                currentIndex = 0;
            }
        }
    }

    public void Die()
    {
        link.state = new DamagedLinkState(link);
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

    public void DrawAttacker(SpriteBatch spriteBatch)
    {
        Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
        Rectangle sourceRect = attackingLinkSprites[currentIndex];
        link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, sourceRect.Height - 16);
    }
}