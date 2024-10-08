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

    //buffer for animation
    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 5;

    private String weapon;

    //set defaults
    public RightAttackingLinkState(Link link, String weapon)
    {
        this.link = link;
        this.weapon = weapon;
        bufferIndex = 0;
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
        link.state = new DamagedLinkState(link);
    }

    //draws link for respective weapon type
    public void Draw(SpriteBatch spriteBatch)
    {
        if (this.weapon == "Wooden")
        {
            Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
            Rectangle sourceRect = LinkRectStorage.getRightWoodenLinkSprites(currentIndex);
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, 0);
        }
        else if (this.weapon == "Beam")
        {
            Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
            Rectangle sourceRect = LinkRectStorage.getRightWhiteLinkSprites(currentIndex);
            link.DrawSprite(spriteBatch, downMovingLink, sourceRect, 0, 0);
        }
    }

    //update for animation
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

    public void DrawAttackingLink(SpriteBatch spriteBatch)
    {
        throw new NotImplementedException();
    }
}