using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class GelSprite : ISprite
{
    private Texture2D gelTexture;

    private Rectangle destinationRectangle;
    private Rectangle sourceRectangle;

    private int XPos;
    private int YPos;

    private int XRectStart;
    private int YRectStart;

    public GelSprite(Texture2D spritsheet)
    {
        this.gelTexture = spritsheet;

        XPos = 150;
        YPos = 150;

        destinationRectangle = new Rectangle(XPos, YPos, 16, 16);

        //Set gel rectangles
    }

    public void draw()
    {

    }

    public void update()
    {

    }
}