using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class WallmasterSprite : ISprite
{
    private Texture2D wallmasterTexture;

    private Rectangle destinationRectangle;
    private Rectangle sourceRectangle;

    private int XPos;
    private int YPos;

    private int XRectStart;
    private int YRectStart;

    public WallmasterSprite(Texture2D spritsheet)
    {
        this.wallmasterTexture = spritsheet;

        XPos = 150;
        YPos = 150;

        destinationRectangle = new Rectangle(XPos, YPos, 16, 16);

        //Set Wallmaster rectangles
    }

    public void draw()
    {

    }

    public void update()
    {

    }
}