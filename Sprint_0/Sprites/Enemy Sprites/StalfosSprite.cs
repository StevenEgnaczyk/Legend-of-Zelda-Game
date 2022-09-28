using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class StalfosSprite : ISprite
{
    private Texture2D stalfosTexture;

    private Rectangle destinationRectangle;
    private Rectangle sourceRectangle;

    private int XPos;
    private int YPos;

    private int XRectStart;
    private int YRectStart;

    public StalfosSprite(Texture2D spritsheet)
    {
        this.stalfosTexture = spritsheet;

        XPos = 150;
        YPos = 150;

        destinationRectangle = new Rectangle(XPos, YPos, 16, 16);

        //Set Stalfos rectangles
    }

    public void draw()
    {

    }

    public void update()
    {

    }
}