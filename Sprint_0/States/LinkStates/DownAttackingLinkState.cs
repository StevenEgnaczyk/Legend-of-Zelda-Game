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
    private static List<Rectangle> linkSprites = new List<Rectangle>()
    {
        new Rectangle(1, 47, 16, 15),
        new Rectangle(18, 47, 16, 27),
        new Rectangle(35, 47, 15, 23),
        new Rectangle(53, 47, 13, 19)
    };

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 10;

    public DownAttackingLinkState(Link link)
    {
        this.link = link;
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
        link.state = new DownAttackingLinkState(link);
    }

    public void Die()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D downMovingLink = Texture2DStorage.GetLinkSpriteSheet();
        Rectangle sourceRect = linkSprites[currentIndex];
        link.DrawSprite(spriteBatch, downMovingLink, sourceRect);

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