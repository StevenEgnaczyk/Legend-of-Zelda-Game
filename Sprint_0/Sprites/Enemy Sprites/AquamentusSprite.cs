using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class AquamentusSprite : ISprite
{
    private Texture2D AquamentusTexture;

    private Rectangle destinationRectangle;
    private Rectangle sourceRectangle;

    private int XPos;
    private int YPos;

    private int XRectStart;
    private int YRectStart;

    public AquamentusSprite(Textur2D spritesheet)
    {
        this.AquamentusTexture = spritsheet;

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