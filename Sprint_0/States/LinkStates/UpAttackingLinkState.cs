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
    private static List<Rectangle> woodenSwordSprites = new List<Rectangle>()
    {
        new Rectangle(1, 109, 16, 16),
        new Rectangle(54, 106, 12, 19),
        new Rectangle(37, 100, 12, 25),
        new Rectangle(18, 97, 16, 28),
        
        
    };

    private static List<Rectangle> whiteSwordSprites = new List<Rectangle>()
    {
        new Rectangle(94, 109, 16, 16),
        new Rectangle(147, 106, 12, 19),
        new Rectangle(130, 101, 12, 24),
        new Rectangle(111, 96, 16, 29),
        
    };

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
            Rectangle sourceRect = woodenSwordSprites[currentIndex];
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, -sourceRect.Height);
        }
        else if (this.weapon == "Beam")
        {
            Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
            Rectangle sourceRect = whiteSwordSprites[currentIndex];
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

    public void DrawAttacker(SpriteBatch spriteBatch)
    {
        throw new NotImplementedException();
    }
}