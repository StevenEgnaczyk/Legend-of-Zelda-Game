using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class RightAttackingLinkState : ILinkState
{
    private Link link;
    private static List<Rectangle> woodenSwordSprites = new List<Rectangle>()
    {
        new Rectangle(1, 78, 15, 15),
        new Rectangle(70, 77, 19, 16),
        new Rectangle(46, 78, 23, 15),
        new Rectangle(18, 78, 27, 15)
    };

    private static List<Rectangle> whiteSwordSprites = new List<Rectangle>()
    {
        new Rectangle(94, 78, 15, 15),
        new Rectangle(163, 77, 19, 16),
        new Rectangle(139, 78, 21, 15),
        new Rectangle(111, 78, 26, 15)
    };



    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 5;

    private String weapon;

    public RightAttackingLinkState(Link link, String weapon)
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
        link.state = new RightAttackingLinkState(link, "Wooden");
    }

    public void UseSwordBeam()
    {
        link.state = new RightAttackingLinkState(link, "Beam");
    }

    public void UseBoomerang()
    {
        link.state = new RightAttackingLinkState(link, "Boomerang");
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
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, 0);
        }
        else if (this.weapon == "Beam")
        {
            Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
            Rectangle sourceRect = whiteSwordSprites[currentIndex];
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, 0);
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
                link.state = new RightMovingLinkState(link);
                currentIndex = 0;
            }
        }
    }

    public void UseBow()
    {
        throw new NotImplementedException();
    }

    public void UseBoomerang()
    {
        link.state = new DownAttackingLinkState(link, "Boomerang");
    }
}