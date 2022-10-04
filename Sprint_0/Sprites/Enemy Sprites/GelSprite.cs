using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class GelSprite : IEnemySprite
{
    private Texture2D gelTexture;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;


    public GelSprite(Texture2D spritsheet)
    {
        this.gelTexture = spritsheet;

        this.destinationRectangle = new Rectangle(0, 0, 32, 32);
        this.frame0Rectangle = new Rectangle(1, 11, 8, 16);
        this.frame1Rectangle = new Rectangle(10, 11, 8, 16);

    }

    public void draw(int frame, SpriteBatch sb)
    {
        if ((frame % 2) == 0)
        {
            sb.Draw(this.gelTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

        }
        else
        {
            sb.Draw(this.gelTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);

        }
    }

    public void update(int xPos, int yPos)
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 32, 32);
    }
}