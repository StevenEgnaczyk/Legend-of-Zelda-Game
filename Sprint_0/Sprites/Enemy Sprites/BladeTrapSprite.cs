using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class BladeTrapSprite : ISprite
{
    private Texture2D BladeTrapTexture;

    private Rectangle destinationRectangle;
    private Rectangle sourceRectangle;

    private int XPos;
    private int YPos;

    private int XRectStart;
    private int YRectStart;

    public BladeTrapSprite(Texture2D spritsheet)
    {
        this.BladeTrapTexture = spritesheet;

        XPos = 150;
        YPos = 150;

        destinationRectangle = new Rectangle(XPos, YPos, 16, 16);
    }

    public void draw()
    {

    }

    public void update()
    {

    }
}