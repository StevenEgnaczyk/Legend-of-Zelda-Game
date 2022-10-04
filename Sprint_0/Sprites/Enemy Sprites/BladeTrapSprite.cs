using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class BladeTrapSprite : IEnemySprite
{
    private Texture2D BladeTrapTexture;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;


    public BladeTrapSprite(Texture2D spritesheet)
    {
        this.BladeTrapTexture = spritesheet;

        this.destinationRectangle = new Rectangle(0, 0, 32, 32);

        this.frame0Rectangle = new Rectangle(164, 59, 16, 16);

    }

    public void draw(int frame, SpriteBatch sb)
    { 
            sb.Draw(this.BladeTrapTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);
    }

    public void update(int xPos, int yPos)
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 32, 32);
    }
}