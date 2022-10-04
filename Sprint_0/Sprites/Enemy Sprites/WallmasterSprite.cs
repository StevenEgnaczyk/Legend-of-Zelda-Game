using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class WallmasterSprite : IEnemySprite
{
    private Texture2D wallmasterTexture;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;

    public WallmasterSprite(Texture2D spritsheet)
    {
        this.wallmasterTexture = spritsheet;

        this.destinationRectangle = new Rectangle(0, 0, 32, 32);
        this.frame0Rectangle = new Rectangle(393, 11, 16, 16);
        this.frame1Rectangle = new Rectangle(410, 11, 16, 16);
    }

    public void draw(int frame, SpriteBatch sb)
    {
        if ((frame % 2) == 0)
        {
            sb.Draw(this.wallmasterTexture, destinationRectangle, this.frame0Rectangle, Color.White);

        }
        else
        {
            sb.Draw(this.wallmasterTexture, destinationRectangle, this.frame1Rectangle, Color.White);

        }
    }

    public void update(int xPos, int yPos)
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 32, 32);
    }
}