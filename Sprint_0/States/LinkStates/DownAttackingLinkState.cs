using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    private int bufferIndex;
    private int bufferMax = 5;

    public DownAttackingLinkState(Link link, String weapon)
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
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, sourceRect.Height - 16);
        } else if (this.weapon == "Beam")
        {
            Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
            Rectangle sourceRect = whiteSwordSprites[currentIndex];
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, sourceRect.Height - 16);
        }  else
        {

        }

    }

    public void DrawAttacker(SpriteBatch spriteBatch)
    {

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
                link.state = new DownMovingLinkState(link);
                currentIndex = 0;
            }
        }
    }



    public void UseBow()
    {
        throw new NotImplementedException();
    }
}